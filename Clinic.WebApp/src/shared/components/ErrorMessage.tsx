function ErrorMessage({
  message,
}: {
  message: string | undefined;
}): React.JSX.Element {
  return (
    <>
      <span className="text-danger">{message}</span>
    </>
  );
}

export default ErrorMessage;
