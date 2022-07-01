SELECT
    p.id,
    p.name,
    p.price,
    p.producer_name,
    d.id as discount_id,
    d.name as discount_name,
    d.percentage as discount_percentage,
    d.date_from as discount_date_from,
    d.date_to as discount_date_to
FROM ropuszka.product p
JOIN ropuszka.product_discount pd ON pd.id_product = p.id
JOIN ropuszka.discount d ON pd.id_discount = d.id;
