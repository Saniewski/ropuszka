import { faker } from '@faker-js/faker';
import {
  ClientDto,
  DiscountDto,
  ProductDto,
  ProductDiscountDto,
  ProductPurchaseDto,
  PurchaseDto,
  ShopDto
} from '../models';
import ropuszkaService from '../services/ropuszka.service';

faker.seed(123);

async function generateFakeClient(): Promise<ClientDto> {
  let nextId = await ropuszkaService.getNextIdForTable('client');
  let name = faker.name.firstName() + ' ' + faker.name.lastName();
  let dateOfBirth = new Date(faker.date.past().toISOString().slice(0, 10));
  let emailAddress = faker.internet.email();
  return {
    id: nextId,
    name: name,
    date_of_birth: dateOfBirth,
    email_address: emailAddress
  };
};

async function generateFakeDiscount(): Promise<DiscountDto> {
  let nextId = await ropuszkaService.getNextIdForTable('discount');
  let name = faker.lorem.word();
  let percentage = faker.datatype.number({ min: 0, max: 1, precision: 2 });
  let dateFrom = new Date(faker.date.between('2019-01-01', '2022-12-31').toISOString().slice(0, 10));
  let dateTo = new Date();
  dateTo.setDate(dateFrom.getDate() + faker.datatype.number({ min: 1, max: 30 }));
  return {
    id: nextId,
    name: name,
    percentage: percentage,
    date_from: dateFrom,
    date_to: dateTo
  };
};

async function generateFakeProductDiscount(): Promise<ProductDiscountDto> {
  let nextId = await ropuszkaService.getNextIdForTable('product_discount');
  let idProduct = faker.datatype.number({ min: 1,
    max: await ropuszkaService.getNextIdForTable('product') });
  let idDiscount = faker.datatype.number({ min: 1,
    max: await ropuszkaService.getNextIdForTable('discount') });
  return {
    id: nextId,
    id_product: idProduct,
    id_discount: idDiscount
  };
};

async function generateFakeProductPurchase(): Promise<ProductPurchaseDto> {
  let nextId = await ropuszkaService.getNextIdForTable('product_purchase');
  let idProduct = faker.datatype.number({ min: 1,
    max: await ropuszkaService.getNextIdForTable('product') });
  let idPurchase = faker.datatype.number({ min: 1,
    max: await ropuszkaService.getNextIdForTable('purchase') });
  let quantity = faker.datatype.number({ min: 1, max: 10 });
  return {
    id: nextId,
    id_product: idProduct,
    id_purchase: idPurchase,
    quantity: quantity
  };
};

async function generateFakeProduct(): Promise<ProductDto> {
  let nextId = await ropuszkaService.getNextIdForTable('product');
  let name = faker.commerce.productName();
  let price = parseFloat(faker.commerce.price());
  let producer_name = faker.company.companyName();
  return {
    id: nextId,
    name: name,
    price: price,
    producer_name: producer_name
  };
};

async function generateFakePurchase(): Promise<PurchaseDto> {
  let nextId = await ropuszkaService.getNextIdForTable('purchase');
  let date = new Date(faker.date.between('2019-01-01', '2022-12-31').toISOString().slice(0, 10));
  let idShop = faker.datatype.number({ min: 1,
    max: await ropuszkaService.getNextIdForTable('shop') });
  let idClient = faker.datatype.number({ min: 1,
    max: await ropuszkaService.getNextIdForTable('client') });
  return {
    id: nextId,
    date: date,
    id_shop: idShop,
    id_client: idClient
  };
};

async function generateFakeShop(): Promise<ShopDto> {
  let nextId = await ropuszkaService.getNextIdForTable('shop');
  let address = faker.address.streetAddress();
  let phone_number = faker.phone.number();
  let email_address = faker.internet.email();
  return {
    id: nextId,
    address: address,
    phone_number: phone_number,
    email_address: email_address
  };
};

export default {
  generateFakeClient,
  generateFakeDiscount,
  generateFakeProductDiscount,
  generateFakeProductPurchase,
  generateFakeProduct,
  generateFakePurchase,
  generateFakeShop
};
