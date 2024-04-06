class Guard {
  public static Against = new Guard();

  public EmptyString(input: string, message?: string): string {
    if (input.length === 0 || input === "") {
      throw new Error("The required input was empty" ?? message);
    }

    return input;
  }

  public EmptyObject(input: object, message?: string): object {
    if (Object.entries(input).length === 0) {
      throw new Error("The required input was empty" ?? message);
    }

    return input;
  }

  public EmptyObjectEntry(input: object, message?: string): object {
    const entries = Object.entries(input).reduce(
      (acc: string[], value: string[]) => [...acc, ...value],
      []
    );

    for (const entry of entries) {
      if (entry.length > 0) continue;

      throw new Error("The required object entry are empty" ?? message);
    }

    return input;
  }
}

export default Guard;
