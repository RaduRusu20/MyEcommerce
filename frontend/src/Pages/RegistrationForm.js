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
    document.getElementById("avatar").remove();
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

  const submit = async (data) => {
    let formData = new FormData();
    data.role = 1;
    const fileInput = document.getElementById("avatar");
    const file = fileInput.files[0];
    formData.append("image", file);

    await axios({
      method: "post",
      url: "https://myecommercewebapi.azurewebsites.net/api/Users/UploadPhoto",
      data: formData,
    })
      .then(function (response) {
        data.ProfileImgUrl = response.data;
        console.log(response);
      })
      .catch(function (response) {
        //handle error
        console.log(response);
      });

    await axios
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
        <Box className={RegistrationFormStyle.center}>
          <form
            style={{
              display: "flex",
              flexDirection: "column",
              alignItems: "center",
              textAlign: "center",
            }}
            ref={form}
            className={classes.root}
            autoComplete="on"
            onSubmit={handleSubmit((data) => submit(data))}
          >
            <h2>Sign Up</h2>
            <div
              style={{
                display: "flex",
                width: "400px",
                justifyContent: "space-evenly",
              }}
            >
              <div
                style={{
                  display: "flex",
                  flexDirection: "column",
                  textAlign: "start",
                }}
              >
                <TextField
                  style={{ width: "150px" }}
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
              </div>
              <div
                style={{
                  display: "flex",
                  flexDirection: "column",
                  textAlign: "start",
                }}
              >
                <TextField
                  style={{ width: "150px" }}
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
              </div>
            </div>
            <div
              style={{
                display: "flex",
                width: "400px",
                justifyContent: "space-evenly",
              }}
            >
              <div
                style={{
                  display: "flex",
                  flexDirection: "column",
                  textAlign: "start",
                }}
              >
                <TextField
                  style={{ width: "150px" }}
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
              </div>
              <div
                style={{
                  display: "flex",
                  flexDirection: "column",
                  textAlign: "start",
                }}
              >
                <TextField
                  style={{ width: "150px" }}
                  variant="outlined"
                  id="outlined-basic"
                  label="Password"
                  size="small"
                  {...register("password", {
                    required: "Required",
                    pattern: {
                      value:
                        /(?=.*?[a-z])(?=.*?[A-Z])(?=.*?[0-9])[a-zA-Z0-9]{8,}/,
                      message: "1 capital letter, digits, minLength > 8",
                    },
                  })}
                  type="password"
                />
                <p className={RegistrationFormStyle.errorMessage}>
                  {errors.password?.message}
                </p>
              </div>
            </div>
            <div
              style={{
                display: "flex",
                width: "400px",
                justifyContent: "space-evenly",
              }}
            >
              <div
                style={{
                  display: "flex",
                  flexDirection: "column",
                  textAlign: "start",
                }}
              >
                <TextField
                  style={{ width: "150px" }}
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
              </div>
              <div
                style={{
                  display: "flex",
                  flexDirection: "column",
                  textAlign: "start",
                }}
              >
                <TextField
                  style={{ width: "150px" }}
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
              </div>
            </div>
            <div
              style={{
                display: "flex",
                width: "400px",
                justifyContent: "space-evenly",
              }}
            >
              <div
                style={{
                  display: "flex",
                  flexDirection: "column",
                  textAlign: "start",
                }}
              >
                <label for="avatar">Choose a profile picture:</label>
                <input type="file" id="avatar" name="avatar"></input>
              </div>
            </div>

            <br></br>

            <div
              style={{
                display: "flex",
                width: "400px",
                justifyContent: "space-evenly",
              }}
            >
              <Button
                size="large"
                type="submit"
                variant="contained"
                color="secondary"
              >
                Register
              </Button>
              <Button
                size="large"
                variant="contained"
                color="primary"
                style={{ width: "122.115px" }}
              >
                <Link
                  to={"/SignIn"}
                  style={{ color: "white", textDecoration: "none" }}
                >
                  Login
                </Link>
              </Button>
            </div>
          </form>
        </Box>
      </Layout>
    </>
  );
}

export default RegistrationForm;
