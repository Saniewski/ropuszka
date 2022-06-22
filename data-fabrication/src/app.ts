import dataGenerator from "./helpers/data-generator.helper";
import ropuszkaService from "./services/ropuszka.service";

const shopsCount = 1000;
const productsCount = 100000;
const clientsCount = 10000000;
const discountsCount = 10000;
const productDiscountsCount = 400000;
const purchasesCount = 100000000;
const productPurchasesCount = 500000000;

generateMockedData(shopsCount, productsCount, clientsCount, discountsCount, productDiscountsCount, purchasesCount, productPurchasesCount);

function generateMockedData(
  shopsCount: number,
  productsCount: number,
  clientsCount: number,
  discountsCount: number,
  productDiscountsCount: number,
  purchasesCount: number,
  productPurchasesCount: number
  ): void {
  // generate shops
  for (let i = 0; i < shopsCount; i++) {
    dataGenerator.generateFakeShop()
      .then(shop => {
        ropuszkaService.addShop(shop);
      })
      .catch(err => {
        console.log(err);
      }
    );
  }
  console.log(`Finished generating '${shopsCount}' shops`);
  
  // generate products
  for (let i = 0; i < productsCount; i++) {
    dataGenerator.generateFakeProduct()
      .then(product => {
        ropuszkaService.addProduct(product);
      })
      .catch(err => {
        console.log(err);
      }
    );
  }
  console.log(`Finished generating '${productsCount}' products`);

  // generate clients
  for (let i = 0; i < clientsCount; i++) {
    dataGenerator.generateFakeClient()
      .then(client => {
        ropuszkaService.addClient(client);
      })
      .catch(err => {
        console.log(err);
      }
    );
  }
  console.log(`Finished generating '${clientsCount}' clients`);

  // generate discounts
  for (let i = 0; i < discountsCount; i++) {
    dataGenerator.generateFakeDiscount()
      .then(discount => {
        ropuszkaService.addDiscount(discount);
      })
      .catch(err => {
        console.log(err);
      }
    );
  }
  console.log(`Finished generating '${discountsCount}' discounts`);

  // generate product_discounts
  for (let i = 0; i < productDiscountsCount; i++) {
    dataGenerator.generateFakeProductDiscount()
      .then(productDiscount => {
        ropuszkaService.addProductDiscount(productDiscount);
      })
      .catch(err => {
        console.log(err);
      }
    );
  }
  console.log(`Finished generating '${productDiscountsCount}' product_discounts`);

  // generate purchases
  for (let i = 0; i < purchasesCount; i++) {
    dataGenerator.generateFakePurchase()
      .then(purchase => {
        ropuszkaService.addPurchase(purchase);
      })
      .catch(err => {
        console.log(err);
      }
    );
  }
  console.log(`Finished generating '${purchasesCount}' purchases`);

  // generate product_purchases
  for (let i = 0; i < productPurchasesCount; i++) {
    dataGenerator.generateFakeProductPurchase()
      .then(productPurchase => {
        ropuszkaService.addProductPurchase(productPurchase);
      })
      .catch(err => {
        console.log(err);
      }
    );
  }
  console.log(`Finished generating '${productPurchasesCount}' product purchases`);
}
