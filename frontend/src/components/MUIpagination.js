import * as React from "react";
import Typography from "@mui/material/Typography";
import Pagination from "@mui/material/Pagination";
import Stack from "@mui/material/Stack";

export default function PaginationControlled({ noOfPages, paginate }) {
  const [page, setPage] = React.useState(1);
  const handleChange = (event, value) => {
    setPage(value);
    paginate(value);
  };

  return (
    <Stack spacing={2}>
      <Typography style={{ display: "flex", justifyContent: "center" }}>
        Page: {page}
      </Typography>
      <Pagination
        style={{ display: "flex", justifyContent: "center" }}
        showFirstButton
        showLastButton
        count={noOfPages}
        page={page}
        onChange={handleChange}
      />
    </Stack>
  );
}
