import React from "react";
import { useState } from "react";
import Constants from "../utilities/Constants";
export default function UpdateEmployeeForm(props) {
  const initialFormData = Object.freeze({
    name: props.employee.name,
    status: props.employee.status,
    numberOfItemsProduced: props.employee.numberOfItemsProduced,
  });
  const [formData, setFormData] = useState(initialFormData);

  const handleChange = (e) => {
    setFormData({
      ...formData,
      [e.target.name]: e.target.value,
    });
  };
  const handleSubmit = (e) => {
    e.preventDefault();
    const employeeToUpdate = {
      id: props.employee.id,
      name: formData.name,
      status: parseInt(formData.status),
      numberOfItemsProduced: parseInt(formData.numberOfItemsProduced),
      employee_Machine: null,
    };
    const url = "http://localhost:6772/admin/api/Employees";

    fetch(url, {
      method: "PUT",
      headers: {
        Accept: "application/json, text/plain",
        "Content-Type": "application/json; charset=utf-8",
        "Access-Control-Request-Method": "POST",
      },
      body: JSON.stringify(employeeToUpdate),
    })
      .then((response) => response.json())
      .then(console.log(JSON.stringify(employeeToUpdate)))
      .catch((error) => {
        console.log(error);
        alert(error);
      });

    props.onEmployeeUpdated(employeeToUpdate);
  };
  return (
    <div>
      <form action="" className="w-100 px-5">
        <h1 className="mt-5">Update Employee "{props.employee.name}"</h1>
        <div className="mt-5">
          <label htmlFor="" className="h3 form-label">
            Employee name
          </label>
          <input
            type="text"
            value={formData.name}
            name="name"
            className="form-control"
            onChange={handleChange}
          />
        </div>
        <div className="mt-4">
          <label htmlFor="" className="h3 form-label">
            Employee status
          </label>
          <input
            type="number"
            step="1"
            value={formData.status}
            name="status"
            className="form-control"
            onChange={handleChange}
          />
        </div>
        <div className="mt-5">
          <label htmlFor="" className="h3 form-label">
            numbers of items produced
          </label>
          <input
            type="number"
            value={formData.numberOfItemsProduced}
            name="numberOfItemsProduced"
            className="form-control"
            onChange={handleChange}
          />
        </div>
        <button
          onClick={handleSubmit}
          className="btn btn-dark btn-lg w-100 mt-5"
        >
          Submit
        </button>
        <button
          onClick={() => props.onEmployeeUpdated(null)}
          className="btn btn-secondary btn-lg w-100 mt-3"
        >
          Cancel
        </button>
      </form>
    </div>
  );
}
