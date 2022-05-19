import React from "react";
import Box from "@mui/material/Box";
import RegistrationFormStyle from "../style/RegistrationForm.module.css";
import { makeStyles } from "@material-ui/core/styles";
import Button from "@material-ui/core/Button";
import { useForm } from "react-hook-form";
import TextField from "@material-ui/core/TextField";
import Layout from "../Layouts/CustomerLayout";
import { useState, useEffect } from "react";
import { useContext } from "react";
import { UserContext } from "../Services/UserContext";
import { Link } from "react-router-dom";
import { Navigate } from "react-router-dom";

const useStyles = makeStyles((theme) => ({
  root: {
    "& > *": {
      margin: theme.spacing(1),
      width: "25ch",
    },
  },
}));

function LoginForm() {
  const classes = useStyles();

  const { login } = useContext(UserContext);

  const usersUrl = "https://localhost:7090/api/Users";
  const [users, setUsers] = useState([]);
  const [isLoggedIn, setIsLoggedIn] = useState("progress");
  const [homePage, setHomePage] = useState("/");

  const getData = async () => {
    const response = await fetch(usersUrl);
    const result = await response.json();
    setUsers(result);
  };

  useEffect(() => {
    getData();
  }, []);

  const {
    register,
    formState: { errors },
    handleSubmit,
  } = useForm();

  const Submit = (data) => {
    let ok = false;
    let aux = {};
    users.forEach((user) => {
      if (user.email === data.email && user.password === data.password) {
        ok = true;
        aux = user;
      }
    });

    if (ok === true) {
      login(aux.email, aux.role);
      aux.role === 1 ? setHomePage("/") : setHomePage("/admin");
      setIsLoggedIn("ok");
    } else {
      setIsLoggedIn("not ok");
    }
  };

  return (
    <>
      {isLoggedIn !== "ok" ? null : <Navigate to={homePage} />}
      <Layout>
        <Box gap={3} className={RegistrationFormStyle.center}>
          <img
            className={RegistrationFormStyle.pic}
            width={"590"}
            height={"480"}
            src={
              "https://www.businessnewsdaily.com/images/i/000/005/645/original/ecommerce.jpg?1396899072"
            }
            alt="Not loading..."
          />

          <form
            className={classes.root}
            autoComplete="on"
            onSubmit={handleSubmit((data) => Submit(data))}
          >
            <h2>Sign In</h2>
            <TextField
              variant="outlined"
              id="outlined-basic"
              label="Email"
              size="small"
              {...register("email", {
                required: "Required",
                pattern: {
                  value:
                    /^[a-zA-Z0-9.!#$%&’*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:.[a-zA-Z0-9-]+)*$/,
                  message: "Not a valid email",
                },
              })}
              type="email"
            />
            <p className={RegistrationFormStyle.errorMessage}>
              {errors.email?.message}
            </p>
            <TextField
              variant="outlined"
              id="outlined-basic"
              label="Password"
              size="small"
              {...register("password", {
                required: "Required",
                pattern: {
                  value: /(?=.*?[a-z])(?=.*?[A-Z])(?=.*?[0-9])[a-zA-Z0-9]{8,}/,
                  message: "1 capital letter, digits, minLength > 8",
                },
              })}
              type="password"
            />
            <p className={RegistrationFormStyle.errorMessage}>
              {errors.password?.message}
            </p>
            {isLoggedIn === "not ok" && (
              <p className={RegistrationFormStyle.errorMessage}>
                Invalid credentials!
              </p>
            )}
            <Button
              size="large"
              type="submit"
              variant="contained"
              color="secondary"
            >
              Login
            </Button>

            <Button size="large" variant="contained" color="primary">
              <Link
                to={"/SignUp"}
                style={{ color: "white", textDecoration: "none" }}
              >
                Sign Up
              </Link>
            </Button>
          </form>
        </Box>
      </Layout>
    </>
  );
}

export default LoginForm;
