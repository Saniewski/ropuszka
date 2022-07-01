SELECT json_agg(json_build_object(
    'id', s.id,
    'address', s.address,
    'phone_number', s.phone_number,
    'email_address', s.email_address,
    'purchases', COALESCE((
        SELECT json_agg(json_build_object(
            'IdPurchase', p.id,
            'Date', p.date,
            'Client', COALESCE((
                SELECT json_agg(json_build_object(
                    'IdClient', s.id,
                    'Name', s.address,
                    'DateOfBirth', s.date_of_birth,
                    'EmailAddress', s.email_address
                ))
                FROM ropuszka.client c
                WHERE c.id = p.id_client
            ), 'null'::json),
            'PurchasedProducts': COALESCE((
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
        WHERE p.id_shop = s.id
    ), '[]'::json)
)) AS shops
FROM ropuszka.shop s;
