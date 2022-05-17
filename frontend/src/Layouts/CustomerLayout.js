import React from "react";
import Footer from "../components/Footer";
import Header from "../components/CustomerNavbar";

const Layout = ({ children }) => {
  return (
    <>
      <Header />
      <br />
      <main>{children}</main>
      <br />
      <Footer />
    </>
  );
};

export default Layout;
