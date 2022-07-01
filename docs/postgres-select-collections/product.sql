SELECT json_agg(json_build_object(
    'id', p.id,
    'name', p.name,
    'price', p.price,
    'producer_name', p.producer_name,
    'discounts', COALESCE((
        SELECT json_agg(json_build_object(
            'IdDiscount', d.id,
            'Name', d.name,
            'Percentage', d.percentage,
            'DateFrom', d.date_from,
            'DateTo', d.date_to
        ))
        FROM ropuszka.discount d
        JOIN ropuszka.product_discount pd ON pd.id_discount = d.id
        WHERE pd.id_product = p.id
    ), '[]'::json)
)) AS products
FROM ropuszka.product p;
