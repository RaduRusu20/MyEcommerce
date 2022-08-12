import React from "react";
import Box from "@mui/material/Box";
import RegistrationFormStyle from "../style/RegistrationForm.module.css";
import { makeStyles } from "@material-ui/core/styles";
import Button from "@material-ui/core/Button";
import { useForm } from "react-hook-form";
import axios from "axios";
import TextField from "@material-ui/core/TextField";
import Layout from "../Layouts/CustomerLayout";
import { Link, Navigate } from "react-router-dom";
import { useState, useRef } from "react";
import emailjs from "@emailjs/browser";

const useStyles = makeStyles((theme) => ({
  root: {
    "& > *": {
      margin: theme.spacing(1),
      width: "25ch",
    },
  },
}));

function RegistrationForm() {
  const classes = useStyles();
  const [registration, setRegistration] = useState(false);
  const form = useRef();

  const {
    register,
    formState: { errors },
    handleSubmit,
  } = useForm();

  const sendEmail = () => {
    emailjs
      .sendForm(
        "service_ttbx8wr",
        "template_tar52yd",
        form.current,
        "3qzZsevFcsLlsPEEF"
      )
      .then(
        (result) => {
          console.log(result.text);
        },
        (error) => {
          console.log(error.text);
        }
      );
  };

  const submit = (data) => {
    data.role = 1;
    axios
      .post("https://myecommercewebapi.azurewebsites.net/api/Users", data)
      .then(function (response) {
        console.log(response);
      })
      .catch(function (error) {
        console.log(error);
      });
    setRegistration(true);
    sendEmail();
  };

  return (
    <>
      <Layout>
        {registration ? <Navigate to={"/SignIn"} /> : null}
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
            ref={form}
            className={classes.root}
            autoComplete="on"
            onSubmit={handleSubmit((data) => submit(data))}
          >
            <h2>Sign Up</h2>
            <TextField
              variant="outlined"
              id="outlined-basic"
              label="First Name"
              size="small"
              {...register("firstName", {
                required: "Required",
                pattern: {
                  value: /^[A-Z][a-z]+$/,
                  message: "Not a valid first name",
                },
              })}
              type="text"
            />
            <p className={RegistrationFormStyle.errorMessage}>
              {errors.firstName?.message}
            </p>
            <TextField
              variant="outlined"
              id="outlined-basic"
              label="Last Name"
              size="small"
              {...register("lastName", {
                required: "Required",
                pattern: {
                  value: /^[A-Z][a-z]+$/,
                  message: "Not a valid last name",
                },
              })}
              type="text"
            />
            <p className={RegistrationFormStyle.errorMessage}>
              {errors.lastName?.message}
            </p>
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
            <TextField
              variant="outlined"
              id="outlined-basic"
              label="Phone"
              size="small"
              {...register("phone", {
                required: "Required",
                pattern: {
                  value: /^[0-9]{10}$/,
                  message: "Invalid phone number!",
                },
              })}
              type="text"
            />
            <p className={RegistrationFormStyle.errorMessage}>
              {errors.phone?.message}
            </p>
            <TextField
              variant="outlined"
              id="outlined-basic"
              label="Adress"
              size="small"
              {...register("adress", {
                required: "Required",
                pattern: {
                  value: /^[A-Z][a-z .,vm0-9]{4,}/,
                  message: "Invalid adress!",
                },
              })}
              type="text"
            />
            <p className={RegistrationFormStyle.errorMessage}>
              {errors.adress?.message}
            </p>

            <Button
              size="large"
              type="submit"
              variant="contained"
              color="secondary"
            >
              Register
            </Button>
            <Button size="large" variant="contained" color="primary">
              <Link
                to={"/SignIn"}
                style={{ color: "white", textDecoration: "none" }}
              >
                Login
              </Link>
            </Button>
          </form>
        </Box>
      </Layout>
    </>
  );
}

export default RegistrationForm;
