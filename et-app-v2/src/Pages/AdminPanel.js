import React, { useState } from "react";
import { Navigate } from "react-router-dom";
import Constants from "../utilities/Constants";
import CreateEmployeeForm from "../Components/CreateEmployeeForm.js";
import CreateMachineForm from "../Components/CreateMachineForm.js";
import UpdateEmployeeForm from "../Components/UpdateEmployeeForm";
import UpdateMachineForm from "../Components/UpdateMachineForm";
const AdminPanel = () => {
  var A = localStorage.getItem("Role");
  if (A !== "A") {
    alert("Not Authorized.");
    console.log("nope");
    console.log(A);
    Navigate({ to: "/" });
  }
  const [products, setProducts] = useState([]);
  const [machines, setMachines] = useState([]);
  const [employees, setEmployees] = useState([]);
  const [showingCreateNewEmployeeForm, setShowingCreateNewEmployeeForm] =
    useState(false);
  const [showingCreateNewMachineForm, setShowingCreateNewMachineForm] =
    useState(false);
  const [employeeCurrentlyBeingUpdated, setEmployeeCurrentlyBeingUpdated] =
    useState(null);
  const [machineCurrentlyBeingUpdated, setMachineCurrentlyBeingUpdated] =
    useState(null);
  function getEmployees() {
    const url = Constants.API_URL_GET_ALL_EMPLOYEES;
    fetch(url, {
      method: "GET",
    })
      .then((response) => response.json())
      .then((employeesFromServer) => {
        console.log(employeesFromServer);
        setEmployees(employeesFromServer);
      })
      .catch((error) => {
        console.log(error);
        alert(error);
      });
  }
  function getMachines() {
    const url = "http://localhost:6772/admin/api/machines";
    fetch(url, {
      method: "GET",
    })
      .then((response) => response.json())
      .then((machinesFromServer) => {
        console.log(machinesFromServer);
        setMachines(machinesFromServer);
      })
      .catch((error) => {
        console.log(error);
        alert(error);
      });
  }
  function getProducts() {
    const url = "http://localhost:6772/admin/api/products";
    fetch(url, {
      method: "GET",
    })
      .then((response) => response.json())
      .then((productsFromServer) => {
        console.log(productsFromServer);
        setProducts(productsFromServer);
      })
      .catch((error) => {
        console.log(error);
        alert(error);
      });
  }
  function deleteEmployee(id) {
    const url = "http://localhost:6772/admin/api/Employees";

    fetch(url, {
      method: "DELETE",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(id),
    })
      .then((response) => response.json())
      .then(onEmployeeDeleted(id))
      .catch((error) => {});
  }
  function deleteMachine(id) {
    const url = "http://localhost:6772/admin/api/machines";

    fetch(url, {
      method: "DELETE",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(id),
    })
      .then((response) => response.json())
      .then(onMachineDeleted(id))
      .catch((error) => {});
  }
  function deleteProduct(id) {
    const url = "http://localhost:6772/admin/api/products";

    fetch(url, {
      method: "DELETE",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(id),
    })
      .then((response) => response.json())
      .then(onProductDeleted(id))
      .catch((error) => {});
  }
  return (
    <div className="container">
      <div className="row min-vh-100">
        <div className="col d-flex flex-column justify-content-center align-items-center">
          {employeeCurrentlyBeingUpdated === null &&
            machineCurrentlyBeingUpdated === null &&
            showingCreateNewEmployeeForm === false &&
            showingCreateNewMachineForm === false && (
              <div>
                Hello World
                <div className="mt-5">
                  <button
                    className="btn btn-dark btn-lg mx-3 my-3"
                    onClick={() => getEmployees()}
                  >
                    Get Employees
                  </button>
                  <button
                    className="btn btn-dark btn-lg mx-3 my-3"
                    onClick={() => getMachines()}
                  >
                    Get Machines
                  </button>
                  <button
                    className="btn btn-dark btn-lg mx-3 my-3"
                    onClick={() => getProducts()}
                  >
                    Get Products
                  </button>
                  <button
                    className="btn btn-dark btn-lg mx-3 my-3"
                    onClick={() => setShowingCreateNewEmployeeForm(true)}
                  >
                    Create Employees
                  </button>
                  <button
                    className="btn btn-dark btn-lg mx-3 my-3"
                    onClick={() => setShowingCreateNewMachineForm(true)}
                  >
                    Create Machines
                  </button>
                  <button
                    className="btn btn-dark btn-lg mx-3 my-3"
                    onClick={() => setShowingCreateNewMachineForm(true)}
                  >
                    Create Products
                  </button>
                </div>
              </div>
            )}

          {(employees.length > 0 ||
            machines.length > 0 ||
            products.length > 0) &&
            showingCreateNewEmployeeForm === false &&
            showingCreateNewMachineForm === false &&
            employeeCurrentlyBeingUpdated === null &&
            machineCurrentlyBeingUpdated === null &&
            renderPostsTable(
              employees,
              machines,
              products,
              setProducts,
              setEmployees,
              setMachines
            )}
          {showingCreateNewEmployeeForm && (
            <CreateEmployeeForm onEmployeeCreated={onEmployeeCreated} />
          )}
          {showingCreateNewMachineForm && (
            <CreateMachineForm onMachineCreated={onMachineCreated} />
          )}
          {employeeCurrentlyBeingUpdated !== null && (
            <UpdateEmployeeForm
              employee={employeeCurrentlyBeingUpdated}
              onEmployeeUpdated={onEmployeeUpdated}
            />
          )}
          {machineCurrentlyBeingUpdated !== null && (
            <UpdateMachineForm
              machine={machineCurrentlyBeingUpdated}
              onMachineUpdated={onMachineUpdated}
            />
          )}
          {/* <div className="container">
            <div className="row mt-5">
              <div className="col d-flex flex-column justify-content-center align-items-center">
                <AccountOps />
              </div>
            </div>
          </div>*/}
        </div>
      </div>
    </div>
  );
  function renderPostsTable(
    employees,
    machines,
    products,
    setProducts,
    setEmployees,
    setMachines
  ) {
    return (
      <div className="container">
        {employees.length > 0 ? (
          <div className="col-6">
            <div className="table-responsive mt-5">
              <table className="table table-bordered border-dark">
                <thead>
                  <tr>
                    <th scope="col">Person ID (PK)</th>
                    <th scope="col">Name</th>
                    <th scope="col">Status</th>
                    <th scope="col">Items Produced</th>
                    <th scope="col">Role</th>
                    <th scope="col">Crud Ops.</th>
                  </tr>
                </thead>
                <tbody>
                  {employees.map((employee) => (
                    <tr key={employee.id}>
                      <th scope="row">{employee.id}</th>
                      <td>{employee.name}</td>
                      <td>{employee.status}</td>
                      <td>{employee.numberOfItemsProduced}</td>
                      <td>{employee.role}</td>
                      <td>
                        <button
                          onClick={() =>
                            setEmployeeCurrentlyBeingUpdated(employee)
                          }
                          className="btn btn-dark btn-lg mx-3 my-3"
                        >
                          Update
                        </button>
                        <button
                          onClick={() => {
                            if (
                              window.confirm(
                                `Are you sure you want to delete personal named ${employee.name} ?`
                              )
                            )
                              deleteEmployee(employee.id);
                          }}
                          className="btn btn-secondary btn-lg"
                        >
                          Delete
                        </button>
                      </td>
                    </tr>
                  ))}
                </tbody>
              </table>
              <button
                className="btn btn-secondary btn-lg w-100"
                onClick={() => setEmployees([])}
              >
                Empty Table
              </button>
            </div>
          </div>
        ) : null}

        {machines.length > 0 ? (
          <div className="col-6">
            <div className="table-responsive mt-5">
              <table className="table table-bordered border-dark">
                <thead>
                  <tr>
                    <th scope="col">Machine ID (PK)</th>
                    <th scope="col">Name</th>
                    <th scope="col">Status</th>
                  </tr>
                </thead>
                <tbody>
                  {machines.map((machine) => (
                    <tr key={machine.id}>
                      <th scope="row">{machine.id}</th>
                      <td>{machine.name}</td>
                      <td>{machine.status}</td>
                      <td>
                        <button
                          onClick={() =>
                            setMachineCurrentlyBeingUpdated(machine)
                          }
                          className="btn btn-dark btn-lg mx-3 my-3"
                        >
                          Update
                        </button>
                        <button
                          onClick={() => deleteMachine(machine.id)}
                          className="btn btn-secondary btn-lg"
                        >
                          Delete
                        </button>
                      </td>
                    </tr>
                  ))}
                </tbody>
              </table>
              <button
                className="btn btn-secondary btn-lg w-100"
                onClick={() => setMachines([])}
              >
                Empty Table
              </button>
            </div>
          </div>
        ) : null}

        {products.length > 0 ? (
          <div className="col-6">
            <div className="table-responsive mt-5">
              <table className="table table-bordered border-dark">
                <thead>
                  <tr>
                    <th scope="col">Product ID (PK)</th>
                    <th scope="col">Name</th>
                    <th scope="col">Status</th>
                  </tr>
                </thead>
                <tbody>
                  {products.map((product) => (
                    <tr key={product.id}>
                      <th scope="row">{product.id}</th>
                      <td>{product.name}</td>
                      <td>{product.status}</td>
                      <td>
                        <button className="btn btn-dark btn-lg mx-3 my-3">
                          Update
                        </button>
                        <button
                          onClick={() => deleteProduct(product.id)}
                          className="btn btn-secondary btn-lg"
                        >
                          Delete
                        </button>
                      </td>
                    </tr>
                  ))}
                </tbody>
              </table>
              <button
                className="btn btn-secondary btn-lg w-100"
                onClick={() => setProducts([])}
              >
                Empty Table
              </button>
            </div>
          </div>
        ) : null}
      </div>
    );
  }
  function onEmployeeCreated(createdEmployee) {
    setShowingCreateNewEmployeeForm(false);
    if (createdEmployee === null) {
      return;
    }
    alert(
      `Employee successfully created. After clicking OK, your new Employee named "${createdEmployee.name}" will show up in the table below.`
    );
  }
  function onMachineCreated(createdMachine) {
    setShowingCreateNewEmployeeForm(false);
    if (createdMachine === null) {
      return;
    }
    alert(
      `Employee successfully created. After clicking OK, your new Employee named "${createdMachine.name}" will show up in the table below.`
    );
  }
  function onEmployeeUpdated(updatedEmployee) {
    setEmployeeCurrentlyBeingUpdated(null);
    if (updatedEmployee === null) {
      return;
    }
    let employeeCopy = [...employees];
    const index = employeeCopy.findIndex(
      (employeeCopyEmployee, currentIndex) => {
        if (employeeCopyEmployee.id === updatedEmployee.id) {
          return true;
        }
      }
    );
    if (index !== -1) {
      employeeCopy[index] = updatedEmployee;
    }
    setEmployees(employeeCopy);
    alert(
      `Employee Succesfully updated. After clicking OK, look for the Employee with name ${updatedEmployee.name}`
    );
  }
  function onMachineUpdated(updatedMachine) {
    setMachineCurrentlyBeingUpdated(null);
    if (updatedMachine === null) {
      return;
    }
    let machineCopy = [...employees];
    const index = machineCopy.findIndex((machineCopyMachine, currentIndex) => {
      if (machineCopyMachine.id === updatedMachine.id) {
        return true;
      }
    });
    if (index !== -1) {
      machineCopy[index] = updatedMachine;
    }
    setEmployees(machineCopy);
    alert(
      `Machine Succesfully updated. After clicking OK, look for the Employee with name ${updatedMachine.name}`
    );
  }
  function onEmployeeDeleted(employeeId) {
    let employeeCopy = [...employees];
    const index = employeeCopy.findIndex(
      (employeeCopyEmployee, currentIndex) => {
        if (employeeCopyEmployee.id === employeeId.id) {
          return true;
        }
      }
    );
    if (index !== -1) {
      employeeCopy.splice(index, 1);
    }
    setEmployees(employeeCopy);
    alert("Employee succesfully deleted.");
  }

  function onMachineDeleted(machineId) {
    let machineCopy = [...machines];
    const index = machineCopy.findIndex((machineCopyMachine, currentIndex) => {
      if (machineCopyMachine.id === machineId.id) {
        return true;
      }
    });
    if (index !== -1) {
      machineCopy.splice(index, 1);
    }
    setMachines(machineCopy);
    alert("Machine succesfully deleted.");
  }
  function onProductDeleted(ProductId) {
    let ProductCopy = [...products];
    const index = ProductCopy.findIndex((ProductCopyProduct, currentIndex) => {
      if (ProductCopyProduct.id === ProductId.id) {
        return true;
      }
    });
    if (index !== -1) {
      ProductCopy.splice(index, 1);
    }
    setProducts(ProductCopy);
    alert("Product succesfully deleted.");
  }
};
export default AdminPanel;
