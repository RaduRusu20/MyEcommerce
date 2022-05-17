import React from "react";

const ErrorPageLayout = ({ backgroundColor = "black", children }) => {
  return (
    <>
      <div style={{ backgroundColor, height: "140vh" }}>{children}</div>
    </>
  );
};

export default ErrorPageLayout;
