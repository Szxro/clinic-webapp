import { Error } from "./problem-details.model";

export interface FetchWrapperOptions {
  url: string;
  params?: Record<string, string>;
  headers?: Record<string, string>;
  // eslint-disable-next-line @typescript-eslint/no-explicit-any
  body?: any;
}

// eslint-disable-next-line @typescript-eslint/no-explicit-any
export interface FetchWrapperResponse<TResponse = any> {
  status: number;
  data: TResponse;
  headers?: Headers;
  url: string;
  ok: boolean;
  params?: string;
}

export interface FetchWrapperError {
  code: string;
  status: number;
  message?: string;
  params?: string;
  url: string;
  errors?: FetchError[];
}

export type FetchWrapperDefaultResponse = Omit<FetchWrapperResponse, "data">;

type FetchError = Omit<Error, "errorType">;
