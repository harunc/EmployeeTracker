import React from "react";
import { useState } from "react";
import Constants from "../utilities/Constants";
export default function CreateMachineForm(props) {
  const initialFormData = Object.freeze({
    name: "Name",
    status: "1",
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
    const machineToCreate = {
      id: 0,
      name: formData.name,
      status: 1,
      employee_Machine: null,
    };
    const url = "http://localhost:6772/admin/api/Machines";

    fetch(url, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(machineToCreate),
    })
      .then((response) => response.json())
      .catch((error) => {
        console.log(error);
        alert(error);
      });

    props.onMachineCreated(machineToCreate);
  };
  return (
    <div>
      <form action="" className="w-100 px-5">
        <h1 className="mt-5">Create new Machine</h1>
        <div className="mt-5">
          <label htmlFor="" className="h3 form-label">
            Machine name
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
            Machine status
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
        <button
          onClick={handleSubmit}
          className="btn btn-dark btn-lg w-100 mt-5"
        >
          Submit
        </button>
        <button
          onClick={() => props.onMachineCreated(null)}
          className="btn btn-secondary btn-lg w-100 mt-3"
        >
          Cancel
        </button>
      </form>
    </div>
  );
}
