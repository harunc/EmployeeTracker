import React from "react";
import { useState } from "react";
import Constants from "../utilities/Constants";
export default function CreateEmployeeForm(props) {
  const initialFormData = Object.freeze({
    name: "Name",
    status: "1",
    numberOfItemsProduced: "31",
    role: "U",
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
    const employeeToCreate = {
      id: 0,
      name: formData.name,
      status: 1,
      numberOfItemsProduced: parseInt(formData.numberOfItemsProduced),
      role: "U",
      employee_Machine: null,
    };
    const url = "http://localhost:6772/admin/api/Employees";

    fetch(url, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(employeeToCreate),
    })
      .then((response) => response.json())
      .catch((error) => {
        console.log(error);
        alert(error);
      });

    props.onEmployeeCreated(employeeToCreate);
  };
  return (
    <div>
      <form action="" className="w-100 px-5">
        <h1 className="mt-5">Create new Employee</h1>
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
          onClick={() => props.onEmployeeCreated(null)}
          className="btn btn-secondary btn-lg w-100 mt-3"
        >
          Cancel
        </button>
      </form>
    </div>
  );
}
