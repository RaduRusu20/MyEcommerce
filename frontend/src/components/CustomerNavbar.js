import React, { useContext } from "react";
import { makeStyles } from "@material-ui/core/styles";
import AppBar from "@material-ui/core/AppBar";
import Toolbar from "@material-ui/core/Toolbar";
import { Link } from "react-router-dom";
import NavbarStyle from "../style/NavbarStyle.module.css";
import { UserContext } from "../Services/UserContext";
import LogoutIcon from "@mui/icons-material/Logout";
import LoginIcon from "@mui/icons-material/Login";

const useStyles = makeStyles((theme) => ({
  root: {
    flexGrow: 1,
  },
  menuButton: {
    marginRight: theme.spacing(2),
  },
  title: {
    flexGrow: 1,
  },
}));

export default function NavBar() {
  const classes = useStyles();

  const { user, logout } = useContext(UserContext);

  return (
    <div className={classes.root}>
      <AppBar position="static">
        <Toolbar>
          {user.auth && (
            <p style={{ marginRight: "50px" }}>Hello, {user.name}</p>
          )}

          <Link to="/products" className={NavbarStyle.btn}>
            Products
          </Link>
          <Link to="/" className={NavbarStyle.btn}>
            Home
          </Link>
          <Link to="/categories" className={NavbarStyle.btn}>
            Categories
          </Link>

          {!user.auth && (
            <p style={{ marginLeft: "800px" }}>
              <Link
                to={"/SignUp"}
                style={{ color: "white", textDecoration: "none" }}
              >
                Sign Up
              </Link>
            </p>
          )}

          {!user.auth && (
            <Link
              to={"/SignIn"}
              style={{ color: "white", textDecoration: "none" }}
            >
              <LoginIcon style={{ marginLeft: "20px" }} />
            </Link>
          )}
          {user.auth && <LogoutIcon onClick={() => logout()} />}
        </Toolbar>
      </AppBar>
    </div>
  );
}
