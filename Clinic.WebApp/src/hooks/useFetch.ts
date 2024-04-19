import { useEffect, useState } from "react";
import {
  FetchHookOptions,
  FetchHookResponse,
  FetchHookReturn,
} from "../models/hooks/httpMethodHook.model";
import Guard from "../shared/utils/guard";

function useFetch<TResponse>({
  url,
  params,
  headers,
}: FetchHookOptions): FetchHookReturn<TResponse> {
  const [data, setData] = useState<FetchHookResponse<TResponse> | null>(null);
  const [isLoading, setLoading] = useState(false);
  const [error, setError] = useState<Error | null>(null);

  useEffect(() => {
    const getData = async () => {
      setLoading(true);
      try {
        const request = await fetchRequest<TResponse>(url, params, headers);
        setData(request);
      } catch (error: unknown) {
        if (error instanceof Error) {
          setError(error);
        }
      } finally {
        setLoading(false);
      }
    };
    getData();
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);

  return [data, isLoading, error, setError];
}

const fetchRequest = async <TResponse>(
  url: string,
  params?: Record<string, string>,
  headers?: Record<string, string>
): Promise<FetchHookResponse<TResponse>> => {
  Guard.Against.EmptyString(url, "The request url cant be empty");

  if (params !== undefined) {
    Guard.Against.EmptyObject(params, "The params object cant be empty");

    Guard.Against.EmptyObjectEntry(
      params,
      "The params object entries cant be empty"
    );

    const request = await fetch(url + "?" + new URLSearchParams(params), {
      method: "GET",
      headers: new Headers(headers || { accept: "text/plain" }),
    });

    if (!request.ok) {
      throw new Error("Invalid request, check and try again");
    }

    return {
      status: request.status,
      data: await request.json(),
      url: request.url,
      ok: request.ok,
      params: "" + new URLSearchParams(params),
    };
  }

  const request = await fetch(url, {
    method: "GET",
    headers: new Headers(headers || { accept: "text/plain" }),
  });

  if (!request.ok) {
    throw new Error("Invalid request, check and try again");
  }

  return {
    status: request.status,
    data: await request.json(),
    url: request.url,
    ok: request.ok,
  };
};

export { useFetch };
