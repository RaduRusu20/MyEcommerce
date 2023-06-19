import * as React from "react";
import Button from "@mui/material/Button";
import Menu from "@mui/material/Menu";
import MenuItem from "@mui/material/MenuItem";
import { Link } from "react-router-dom";

export default function BasicMenu() {
  const [anchorEl, setAnchorEl] = React.useState(null);
  const open = Boolean(anchorEl);
  const handleClick = (event) => {
    setAnchorEl(event.currentTarget);
  };
  const handleClose = () => {
    setAnchorEl(null);
  };

  return (
    <>
      <Button
        style={{
          color: "white",
          padding: "0px",
          paddingLeft: "1rem",
        }}
        id="basic-button"
        aria-controls={open ? "basic-menu" : undefined}
        aria-haspopup="true"
        aria-expanded={open ? "true" : undefined}
        onClick={handleClick}
      >
        Tables
      </Button>
      <Menu
        id="basic-menu"
        anchorEl={anchorEl}
        open={open}
        onClose={handleClose}
        MenuListProps={{
          "aria-labelledby": "basic-button",
        }}
      >
        <MenuItem>
          {" "}
          <Link
            to="/admin/users"
            style={{ textDecoration: "none", color: "black" }}
          >
            Users
          </Link>
        </MenuItem>
        <MenuItem>
          {" "}
          <Link
            to="/admin/categories"
            style={{ textDecoration: "none", color: "black" }}
          >
            Categories
          </Link>
        </MenuItem>
        <MenuItem>
          <Link
            to="/admin/products"
            style={{ textDecoration: "none", color: "black" }}
          >
            Products
          </Link>
        </MenuItem>
      </Menu>
    </>
  );
}
