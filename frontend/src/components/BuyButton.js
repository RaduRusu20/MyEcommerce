import * as React from "react";
import Button from "@mui/material/Button";
import AddShoppingCartIcon from "@mui/icons-material/AddShoppingCart";
import Stack from "@mui/material/Stack";

export default function IconLabelButtons() {
  return (
    <Stack direction="row" spacing={2}>
      <Button
        size="large"
        variant="contained"
        endIcon={<AddShoppingCartIcon />}
      >
        Add
      </Button>
    </Stack>
  );
}
