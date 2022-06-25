select 'Clients:', count(1) from ropuszka.client union
select 'Shops:', count(1) from ropuszka.shop union
select 'Products:', count(1) from ropuszka.product union
select 'Purchases:', count(1) from ropuszka.purchase union
select 'Product purchases:', count(1) from ropuszka.product_purchase union
select 'Discounts:', count(1) from ropuszka.discount union
select 'Product discounts', count(1) from ropuszka.product_discount;

