import { ValidHttpMethods } from "../models/http-method.model";
import {
  FetchWrapperDefaultResponse,
  FetchWrapperError,
  FetchWrapperOptions,
} from "../models/wrapper.model";
import Guard from "./guard";
import { isProblemDetails } from "./predicates";

async function makeHttpRequest(
  httpMethod: ValidHttpMethods,
  options: FetchWrapperOptions
): Promise<FetchWrapperDefaultResponse | FetchWrapperError> {
  Guard.Against.EmptyString(options.url, "Invalid URL,check and try again");

  Guard.Against.EmptyObject(
    options.body,
    "Invalid body object, check and try again"
  );

  Guard.Against.EmptyObjectEntry(
    options.body,
    "Invalid object entries, check and try again"
  );

  const response = await fetch(options.url, {
    method: httpMethod,
    body: JSON.stringify(options.body),
    headers: new Headers({
      "Content-Type": "application/json; charset=utf-8",
    }),
  });

  try {
    const result = await response.json();

    if (!isValidStatusCode(response.status) && isProblemDetails(result)) {
      // eslint-disable-next-line @typescript-eslint/no-unused-vars
      const { errorType, ...currentError } = result.error;

      if (result.validationErrors !== undefined) {
        const errors = result.validationErrors.map((error) => {
          // eslint-disable-next-line @typescript-eslint/no-unused-vars
          const { errorType, ...currentValidationError } = error;

          return currentValidationError;
        });

        errors.push(currentError);

        return {
          status: result.status,
          code: getStatusCodeDescription(response.status),
          message: result.title,
          url: response.url,
          errors,
        };
      }

      return {
        status: result.status,
        code: getStatusCodeDescription(response.status),
        message: result.title,
        url: response.url,
        errors: [currentError],
      };
    }
  } catch {
    /* empty */
  }

  return {
    status: response.status,
    url: response.url,
    ok: response.ok,
  };
}

function getStatusCodeDescription(status: number): string {
  switch (status) {
    case 400:
      return "ERR_BAD_REQUEST";
    case 404:
      return "ERR_NOT_FOUND";
    case 409:
      return "ERR_CONFLIT";
    case 500:
      return "ERR_INTERNAL_SERVER_ERROR";
    default:
      return "ERR_UNKNONW_SERVER_ERROR";
  }
}

function isValidStatusCode(status: number): boolean {
  return [200, 204].includes(status);
}

export { makeHttpRequest };
