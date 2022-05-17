import React from "react";
import Footer from "../components/Footer";
import Header from "../components/AdminNavbar";

const AdminLayout = ({ children }) => {
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

export default AdminLayout;
