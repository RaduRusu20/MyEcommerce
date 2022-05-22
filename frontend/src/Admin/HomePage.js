import React from "react";
import Layout from "../Layouts/AdminLayout";
import { useContext } from "react";
import { UserContext } from "../Contexts/UserContext";

function HomePage() {
  const { user } = useContext(UserContext);
  return (
    <>
      <Layout>
        {user.auth && <div>Welcome admin, {user.name}!</div>}
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
      </Layout>
    </>
  );
}

export default HomePage;
