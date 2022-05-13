import React from "react";
import PaginationStyle from "../style/PaginationStyle.module.css";

const Pagination = ({ postsPerPage, totalPosts, paginate }) => {
  const pageNumbers = [];
  for (let i = 1; i <= Math.ceil(totalPosts / postsPerPage); i++) {
    pageNumbers.push(i);
  }
  return (
    <nav>
      <br />
      <br />
      <br />
      <ul className={PaginationStyle.pagination}>
        {pageNumbers.map((number) => (
          <li key={number} className="page-item">
            <a onClick={() => paginate(number)}>{number}</a>
          </li>
        ))}
      </ul>
      <br />
      <br />
    </nav>
  );
};

export default Pagination;
