import { Client, Pool, QueryResult } from 'pg';

const credentials = {
  host: 'localhost',
  database: 'ropuszka',
  user: 'postgres',
  password: 'postgres',
  port: 5432,
  max: 10,
  idleTimeoutMillis: 30000
};

const pool = new Pool(credentials);

async function query(query: string): Promise<QueryResult<any>> {
  return await pool.query(query);
}

export default {
  query
};
