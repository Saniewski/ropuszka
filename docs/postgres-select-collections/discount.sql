SELECT json_agg(json_build_object(
    'id', d.id,
    'name', d.name,
    'percentage', d.percentage,
    'date_from', d.date_from,
    'date_to', d.date_to,
    'discounted_products', COALESCE((
        SELECT json_agg(json_build_object(
            'IdDiscountedProduct', p.id,
            'Name', p.name,
            'Price', p.price,
            'ProducerName', p.producer_name
        ))
        FROM ropuszka.product p
        JOIN ropuszka.product_discount pd ON pd.id_product = p.id
        WHERE pd.id_discount = d.id
    ), '[]'::json)
)) AS discounts
FROM ropuszka.discount d;
