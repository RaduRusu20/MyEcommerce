import React from "react";
import Footer from "../components/Footer";
import Header from "../components/CustomerNavbar";
import { useGlobalContext } from "../Cart/context";
import { UserContext } from "../Contexts/UserContext";
import { useEffect } from "react";

const Layout = ({ children }) => {
  const { fetchCartData } = useGlobalContext();
  const { user } = React.useContext(UserContext);
  useEffect(() => {
    if (user.auth) fetchCartData();
  }, []);
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
