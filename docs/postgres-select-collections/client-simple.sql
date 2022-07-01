SELECT
    c.id,
    c.name,
    c.date_of_birth,
    c.email_address,
    p.id as purchase_id,
    p.date as purchase_date,
    s.id as shop_id,
    s.address as shop_address,
    s.phone_number as shop_phone_number,
    s.email_address as shop_email_address,
    prod.id as product_id,
    prod.name as product_name,
    prod.price as product_price,
    prod.producer_name as product_producer_name,
    pp.quantity as product_quantity,
    d.id as discount_id,
    d.name as discount_name,
    d.percentage as discount_percentage,
    d.date_from as discount_date_from,
    d.date_to as discount_date_to
FROM ropuszka.client c
JOIN ropuszka.purchase p on p.id_client = c.id
JOIN ropuszka.shop s on p.id_shop = s.id
JOIN ropuszka.product_purchase pp on pp.id_purchase = p.id
JOIN ropuszka.product prod on pp.id_product = prod.id
JOIN ropuszka.product_discount pd on pd.id_product = prod.id
JOIN ropuszka.discount d on pd.id_discount = d.id
WHERE d.date_from < p.date and p.date < d.date_to;
