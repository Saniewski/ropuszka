SELECT json_agg(json_build_object(
    'id', c.id,
    'name', c.name,
    'date_of_birth', c.date_of_birth,
    'email_address', c.email_address,
    'purchases', COALESCE((
        SELECT json_agg(json_build_object(
            'IdPurchase', p.id,
            'Date', p.date,
            'Shop', COALESCE((
                SELECT json_agg(json_build_object(
                    'IdShop', s.id,
                    'Address', s.address,
                    'PhoneNumber', s.phone_number,
                    'EmailAddress', s.email_address
                ))
                FROM ropuszka.shop s
                WHERE s.id = p.id_shop
            ), 'null'::json),
            'PurchasedProducts', COALESCE((
                SELECT json_agg(json_build_object(
                    'IdProduct', prod.id,
                    'Name', prod.name,
                    'Price', prod.price,
                    'ProducerName', prod.producer_name,
                    'Quantity', pp.quantity,
                    'Discount', COALESCE((
                    SELECT json_agg(json_build_object(
                        'IdDiscount', d.id,
                        'Name', d.name,
                        'Percentage', d.percentage,
                        'DateFrom', d.date_from,
                        'DateTo', d.date_to
                    ))
                    FROM ropuszka.discount d
                    JOIN ropuszka.product_discount pd ON pd.id_discount = d.id
                    WHERE pd.id_product = prod.id
                    ), 'null'::json)
                    ))
                ))
                FROM ropuszka.product prod
                JOIN ropuszka.product_purchase pp ON pp.id_product = prod.id
                WHERE pp.id_purchase = p.id
            ))
        ))
        FROM ropuszka.purchase p
        WHERE p.id_client = c.id
    ), '[]'::json)
)) AS clients
FROM ropuszka.client c;
