import { Link, Routes, Route, useNavigate, Navigate } from "react-router-dom";

import { useState, useEffect } from "react";
import { wait } from "@testing-library/user-event/dist/utils";

const Home = () => {
  const initialFormData = Object.freeze({
    name: "Name",
    numberOfItemsProduced: "31",
  });

  const navigate = useNavigate();
  const [formData, setFormData] = useState(initialFormData);
  const [status, setStatus] = useState("");

  const handleChange = (e) => {
    setFormData({
      ...formData,
      [e.target.name]: e.target.value,
    });
  };
  const handleSubmit = (e) => {
    e.preventDefault();
    const employeeToLogin = {
      name: formData.name,
      numberOfItemsProduced: parseInt(formData.numberOfItemsProduced),
    };
    const url = "http://localhost:6772/";

    fetch(url, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(employeeToLogin),
    })
      .then((response) => response.json())
      .then((data) => {
        localStorage.setItem("Id", data.id);
        localStorage.setItem("Role", data.role);
        localStorage.setItem("Token", data.token);
      })
      .then((data) => {
        if (localStorage.getItem("Role") == "A") {
          navigate("/admin");
        } else if (localStorage.getItem("Role") == "U") {
          navigate("/employee");
        } else {
          alert("Wrong Username or Password");
        }
      })
      .catch((error) => {
        console.log(error);
        alert(error);
      });
  };
  return (
    <>
      {
        <section>
          <p aria-live="assertive"></p>
          <h1>Sign In</h1>
          <form>
            <label htmlFor="username">Username:</label>
            <input
              type="text"
              id="username"
              autoComplete="off"
              name="name"
              value={formData.name}
              onChange={handleChange}
              required
            />

            <label htmlFor="numberOfItemsProduced">Password:</label>
            <input
              type="password"
              id="numberOfItemsProduced"
              name="numberOfItemsProduced"
              value={formData.numberOfItemsProduced}
              onChange={handleChange}
              required
            />
            <button onClick={handleSubmit}>Sign In</button>
          </form>
          <p>
            Need an Account?
            <br />
            <span className="line">
              {/*put router link here*/}
              <a href="#">Sign Up</a>
            </span>
          </p>
        </section>
      }
    </>
  );
};

export default Home;
