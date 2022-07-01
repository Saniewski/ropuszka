SELECT
    d.id,
    d.name,
    d.percentage,
    d.date_from,
    d.date_to,
    p.id as product_id,
    p.name as product_name,
    p.price as product_price,
    p.producer_name as product_producer_name
FROM ropuszka.discount d
JOIN ropuszka.product_discount pd ON pd.id_discount = d.id
JOIN ropuszka.product p ON pd.id_product = p.id
ORDER BY d.id, p.id;
