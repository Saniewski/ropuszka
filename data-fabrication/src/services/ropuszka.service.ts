import appDb from '../helpers/app-db.helper';
import {
  ClientDto,
  DiscountDto,
  ProductDto,
  ProductDiscountDto,
  ProductPurchaseDto,
  PurchaseDto,
  ShopDto
} from '../models';

async function getNextIdForTable(table: string) : Promise<number> {
  const client = await appDb.getClient();
  const query = `
    SELECT max(id) FROM ropuszka.${table}
  `;
  const result = await appDb.query(client, query);
  await appDb.disconnect(client);
  let nextId = 0;
  if (result.rows[0] !== null) {
    nextId = result.rows[0].max
  }
  return nextId + 1;
}

async function addClient(pClient: ClientDto) {
  const client = await appDb.getClient();
  const query = `
    INSERT INTO ropuszka.client (
      id,
      name,
      date_of_birth,
      email_address
    ) VALUES (
      '${pClient.id}',
      '${pClient.name}',
      '${pClient.date_of_birth}',
      '${pClient.email_address}'
    )
  `;
  const result = await appDb.query(client, query);
  await appDb.disconnect(client);
  return result;
}

async function getAllClients(): Promise<ClientDto[]> {
  const client = await appDb.getClient();
  const query = `
    SELECT * FROM ropuszka.client
  `;
  const result = await appDb.query(client, query);
  await appDb.disconnect(client);
  return result.rows;
}

async function getClientById(id: number): Promise<ClientDto> {
  const client = await appDb.getClient();
  const query = `
    SELECT * FROM ropuszka.client WHERE id = '${id}'
  `;
  const result = await appDb.query(client, query);
  await appDb.disconnect(client);
  return result.rows[0];
}

async function addDiscount(discount: DiscountDto) {
  const client = await appDb.getClient();
  const query = `
    INSERT INTO ropuszka.discount (
      id,
      name,
      percentage,
      date_from,
      date_to
    ) VALUES (
      '${discount.id}',
      '${discount.name}',
      '${discount.percentage}',
      '${discount.date_from}',
      '${discount.date_to}'
    )
  `;
  const result = await appDb.query(client, query);
  await appDb.disconnect(client);
  return result;
}

async function getAllDiscounts(): Promise<DiscountDto[]> {
  const client = await appDb.getClient();
  const query = `
    SELECT * FROM ropuszka.discount
  `;
  const result = await appDb.query(client, query);
  await appDb.disconnect(client);
  return result.rows;
}

async function getDiscountById(id: number): Promise<DiscountDto> {
  const client = await appDb.getClient();
  const query = `
    SELECT * FROM ropuszka.discount WHERE id = '${id}'
  `;
  const result = await appDb.query(client, query);
  await appDb.disconnect(client);
  return result.rows[0];
}

async function addProduct(product: ProductDto) {
  const client = await appDb.getClient();
  const query = `
    INSERT INTO ropuszka.product (
      id,
      name,
      price,
      producer_name
    ) VALUES (
      '${product.id}',
      '${product.name}',
      '${product.price}',
      '${product.producer_name}'
    )
  `;
  const result = await appDb.query(client, query);
  await appDb.disconnect(client);
  return result;
}

async function getAllProducts(): Promise<ProductDto[]> {
  const client = await appDb.getClient();
  const query = `
    SELECT * FROM ropuszka.product
  `;
  const result = await appDb.query(client, query);
  await appDb.disconnect(client);
  return result.rows;
}

async function getProductById(id: number): Promise<ProductDto> {
  const client = await appDb.getClient();
  const query = `
    SELECT * FROM ropuszka.product WHERE id = '${id}'
  `;
  const result = await appDb.query(client, query);
  await appDb.disconnect(client);
  return result.rows[0];
}

async function addProductDiscount(productDiscount: ProductDiscountDto) {
  const client = await appDb.getClient();
  const query = `
    INSERT INTO ropuszka.product_discount (
      id,
      id_product,
      id_discount
    ) VALUES (
      '${productDiscount.id}',
      '${productDiscount.id_product}',
      '${productDiscount.id_discount}'
    )
  `;
  const result = await appDb.query(client, query);
  await appDb.disconnect(client);
  return result;
}

async function getAllProductDiscounts(): Promise<ProductDiscountDto[]> {
  const client = await appDb.getClient();
  const query = `
    SELECT * FROM ropuszka.product_discount
  `;
  const result = await appDb.query(client, query);
  await appDb.disconnect(client);
  return result.rows;
}

async function getProductDiscountById(id: number): Promise<ProductDiscountDto> {
  const client = await appDb.getClient();
  const query = `
    SELECT * FROM ropuszka.product_discount WHERE id = '${id}'
  `;
  const result = await appDb.query(client, query);
  await appDb.disconnect(client);
  return result.rows[0];
}

async function addProductPurchase(productPurchase: ProductPurchaseDto) {
  const client = await appDb.getClient();
  const query = `
    INSERT INTO ropuszka.product_purchase (
      id,
      id_product,
      id_purchase,
      quantity
    ) VALUES (
      '${productPurchase.id}',
      '${productPurchase.id_product}',
      '${productPurchase.id_purchase}',
      '${productPurchase.quantity}'
    )
  `;
  const result = await appDb.query(client, query);
  await appDb.disconnect(client);
  return result;
}

async function getAllProductPurchases(): Promise<ProductPurchaseDto[]> {
  const client = await appDb.getClient();
  const query = `
    SELECT * FROM ropuszka.product_purchase
  `;
  const result = await appDb.query(client, query);
  await appDb.disconnect(client);
  return result.rows;
}

async function getProductPurchaseById(id: number): Promise<ProductPurchaseDto> {
  const client = await appDb.getClient();
  const query = `
    SELECT * FROM ropuszka.product_purchase WHERE id = '${id}'
  `;
  const result = await appDb.query(client, query);
  await appDb.disconnect(client);
  return result.rows[0];
}

async function addPurchase(purchase: PurchaseDto) {
  const client = await appDb.getClient();
  const query = `
    INSERT INTO ropuszka.purchase (
      id,
      date,
      id_shop,
      id_client
    ) VALUES (
      '${purchase.id}',
      '${purchase.date}',
      '${purchase.id_shop}',
      '${purchase.id_client}'
    )
  `;
  const result = await appDb.query(client, query);
  await appDb.disconnect(client);
  return result;
}

async function getAllPurchases(): Promise<PurchaseDto[]> {
  const client = await appDb.getClient();
  const query = `
    SELECT * FROM ropuszka.purchase
  `;
  const result = await appDb.query(client, query);
  await appDb.disconnect(client);
  return result.rows;
}

async function getPurchaseById(id: number): Promise<PurchaseDto> {
  const client = await appDb.getClient();
  const query = `
    SELECT * FROM ropuszka.purchase WHERE id = '${id}'
  `;
  const result = await appDb.query(client, query);
  await appDb.disconnect(client);
  return result.rows[0];
}

async function addShop(shop: ShopDto) {
  const client = await appDb.getClient();
  const query = `
    INSERT INTO ropuszka.shop (
      id,
      address,
      phone_number,
      email_address
    ) VALUES (
      '${shop.id}',
      '${shop.address}',
      '${shop.phone_number}',
      '${shop.email_address}'
    )
  `;
  const result = await appDb.query(client, query);
  await appDb.disconnect(client);
  return result;
}

async function getAllShops(): Promise<ShopDto[]> {
  const client = await appDb.getClient();
  const query = `
    SELECT * FROM ropuszka.shop
  `;
  const result = await appDb.query(client, query);
  await appDb.disconnect(client);
  return result.rows;
}

async function getShopById(id: number): Promise<ShopDto> {
  const client = await appDb.getClient();
  const query = `
    SELECT * FROM ropuszka.shop WHERE id = '${id}'
  `;
  const result = await appDb.query(client, query);
  await appDb.disconnect(client);
  return result.rows[0];
}

export default {
  getNextIdForTable,
  addClient,
  getAllClients,
  getClientById,
  addDiscount,
  getAllDiscounts,
  getDiscountById,
  addProduct,
  getAllProducts,
  getProductById,
  addProductDiscount,
  getAllProductDiscounts,
  getProductDiscountById,
  addProductPurchase,
  getAllProductPurchases,
  getProductPurchaseById,
  addPurchase,
  getAllPurchases,
  getPurchaseById,
  addShop,
  getAllShops,
  getShopById
};
