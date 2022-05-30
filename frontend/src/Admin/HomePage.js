import React from "react";
import Layout from "../Layouts/AdminLayout";
import { useContext } from "react";
import { UserContext } from "../Contexts/UserContext";
import ReadMoreReact from "read-more-react";

function HomePage() {
  const { user } = useContext(UserContext);
  return (
    <>
      <Layout>
        <div style={{ display: "flex", justifyContent: "center" }}>
          <img
            src="https://www.logolynx.com/images/logolynx/a6/a671ef222a6e136f8fe7fd9cfc97e57b.png"
            style={{ maxHeight: "100vh", maxWidth: "100vw" }}
          ></img>
        </div>
        {/* {user.auth && <div>Welcome admin, {user.name}!</div>}
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
        <br /> */}
      </Layout>
    </>
  );
}

export default HomePage;
