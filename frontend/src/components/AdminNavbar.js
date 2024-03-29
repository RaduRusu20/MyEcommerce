import React from "react";
import { makeStyles } from "@material-ui/core/styles";
import AppBar from "@material-ui/core/AppBar";
import Toolbar from "@material-ui/core/Toolbar";
import IconButton from "@material-ui/core/IconButton";
import MenuIcon from "@material-ui/icons/Menu";
import { Link } from "react-router-dom";
import NavbarStyle from "../style/NavbarStyle.module.css";
import LogoutIcon from "@mui/icons-material/Logout";
import { useContext } from "react";
import { UserContext } from "../Contexts/UserContext";
import { useState } from "react";
import { Navigate } from "react-router-dom";
import TableDropDownList from "./TablesDropDown";
import StatisticsDropDown from "./StatisticsDropDown";

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

export default function AdminNavbar() {
  const classes = useStyles();

  const { user, logout } = useContext(UserContext);
  const [redirect, setRedirect] = useState(false);

  return (
    <div className={classes.root}>
      <AppBar position="static">
        <Toolbar
          style={{
            display: "flex",
            flexDirection: "row",
            justifyContent: "space-between",
          }}
        >
          {redirect !== true ? null : <Navigate to={"/"} />}

          <div
            style={{
              display: "flex",
              flexDirection: "row",
              justifyContent: "flex-start",
            }}
          >
            {user.auth && <h4>Hello, {user.name}</h4>}
            {/* <Link to="/admin/users" className={NavbarStyle.btn}>
              Users
            </Link>
            <Link to="/admin/categories" className={NavbarStyle.btn}>
              Categories
            </Link>
            <Link to="/admin/products" className={NavbarStyle.btn}>
              Products
            </Link> */}
            <TableDropDownList />
            <StatisticsDropDown />
          </div>
          {user.auth && (
            <LogoutIcon
              onClick={() => {
                logout();
                setRedirect(true);
              }}
            />
          )}
        </Toolbar>
      </AppBar>
    </div>
  );
}
