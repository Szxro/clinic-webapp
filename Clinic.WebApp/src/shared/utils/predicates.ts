import { ProblemDetails } from "../../models/problem-details.model";
import { FetchWrapperError } from "../../models/wrapper.model";

export const isProblemDetails = (
  response: unknown
): response is ProblemDetails => {
  return (response as ProblemDetails).status !== undefined;
};

export const isWrapperError = (
  response: unknown
): response is FetchWrapperError => {
  return (response as FetchWrapperError).message !== undefined;
};
