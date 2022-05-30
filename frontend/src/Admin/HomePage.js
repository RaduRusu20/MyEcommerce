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
        {user.auth && <div>Welcome admin, {user.name}!</div>}
        <ReadMoreReact
          text={
            "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Quis varius quam quisque id diam vel quam. Nunc eget lorem dolor sed viverra ipsum nunc. Metus dictum at tempor commodo ullamcorper a lacus vestibulum. Dolor purus non enim praesent. Ridiculus mus mauris vitae ultricies leo integer malesuada nunc vel. Ipsum a arcu cursus vitae congue mauris rhoncus aenean vel. Vel pretium lectus quam id leo in vitae. Eget gravida cum sociis natoque penatibus et. Mauris cursus mattis molestie a. Sed nisi lacus sed viverra tellus in hac habitasse. Id neque aliquam vestibulum morbi blandit. Sit amet volutpat consequat mauris nunc congue nisi vitae suscipit."
          }
          min={40}
          readMoreText={"readMoreText"}
        />
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
