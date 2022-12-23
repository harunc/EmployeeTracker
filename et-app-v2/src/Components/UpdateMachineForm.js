import React from "react";
import { useState } from "react";
export default function UpdateMachineForm(props) {
  const initialFormData = Object.freeze({
    name: props.machine.name,
    status: props.machine.status,
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
    const machineToUpdate = {
      id: props.machine.id,
      name: formData.name,
      status: parseInt(formData.status),
      employee_Machine: null,
    };
    const url = "http://localhost:6772/admin/api/Machines";

    fetch(url, {
      method: "PUT",
      headers: {
        Accept: "application/json, text/plain",
        "Content-Type": "application/json; charset=utf-8",
        "Access-Control-Request-Method": "POST",
      },
      body: JSON.stringify(machineToUpdate),
    })
      .then((response) => response.json())
      .then(console.log(JSON.stringify(machineToUpdate)))
      .catch((error) => {
        console.log(error);
        alert(error);
      });

    props.onEMachineUpdated(machineToUpdate);
  };
  return (
    <div>
      <form action="" className="w-100 px-5">
        <h1 className="mt-5">Update Employee "{props.machine.name}"</h1>
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
          onClick={() => props.onMachineUpdated(null)}
          className="btn btn-secondary btn-lg w-100 mt-3"
        >
          Cancel
        </button>
      </form>
    </div>
  );
}
