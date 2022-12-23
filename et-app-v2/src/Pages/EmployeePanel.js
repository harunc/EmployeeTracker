import { useLocation, Navigate } from "react-router-dom";
const EmployeePanel = () => {
  var U = localStorage.getItem("Role");
  if (U != "U") {
    alert("Not Authorized.");
    console.log("nope");
    console.log(U);
    Navigate({ to: "/" });
  }
  return <h1>Employee Panel</h1>;
};

export default EmployeePanel;
