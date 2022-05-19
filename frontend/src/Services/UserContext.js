import React from "react";
import { createContext } from "react";
import { useState } from "react";

export const UserContext = createContext();

export const UserProvider = ({ children }) => {
  const [user, setUser] = useState({
    name: localStorage.getItem("CurrentUser")
      ? JSON.parse(localStorage.getItem("CurrentUser")).name
      : "",
    auth: localStorage.getItem("CurrentUser")
      ? JSON.parse(localStorage.getItem("CurrentUser")).auth
      : false,
    role: localStorage.getItem("CurrentUser")
      ? JSON.parse(localStorage.getItem("CurrentUser")).role
      : 1,
  });

  const login = (name, role) => {
    const profile = {
      name: name,
      auth: true,
      role: role,
    };
    localStorage.setItem("CurrentUser", JSON.stringify(profile));

    setUser((user) => profile);
  };

  const logout = () => {
    setUser((user) => ({
      name: "",
      auth: false,
    }));
    localStorage.removeItem("CurrentUser");
  };

  return (
    <UserContext.Provider value={{ user, login, logout }}>
      {children}
    </UserContext.Provider>
  );
};
