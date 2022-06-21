import { Client } from 'pg';

const credentials = {
  host: 'localhost',
  database: 'ropuszka',
  user: 'postgres',
  password: 'postgres',
  port: 5432
};

async function getClient() {
  const client = new Client(credentials);
  await client.connect();
  return client;
}

async function disconnect(client: Client) {
  await client.end();
}

async function query(client: Client, query: string) {
  const result = await client.query(query);
  return result;
}

export default {
  getClient,
  disconnect,
  query
};
