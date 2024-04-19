import { Route, Routes } from "../../models/routes.model";
import CreateDoctorPosition from "../../pages/doctor-position/CreateDoctorPosition";
import CreateDoctor from "../../pages/doctor/CreateDoctor";
import DeleteDoctor from "../../pages/doctor/DeleteDoctor";
import UpdateDoctor from "../../pages/doctor/UpdateDoctor";
import Home from "../../pages/home/Home";
import CreatePatient from "../../pages/patient/CreatePatient";
import DeletePatient from "../../pages/patient/DeletePatient";
import UpdatePatient from "../../pages/patient/UpdatePatient";
import NotFound from "../components/NotFound";

const router: Route[] = [
  { path: "/", element: <Home /> },
  { path: "/doctor/create", element: <CreateDoctor /> },
  { path: "/doctor/update", element: <UpdateDoctor /> },
  { path: "/doctor/delete", element: <DeleteDoctor /> },
  { path: "/doctorposition/create", element: <CreateDoctorPosition /> },
  { path: "/patient/create", element: <CreatePatient /> },
  { path: "/patient/update", element: <UpdatePatient /> },
  { path: "/patient/delete", element: <DeletePatient /> },
  { path: "*", element: <NotFound /> },
];

const routes: Routes = {
  Doctor: [
    {
      path: "/doctor/create",
      pathChildName: "Create",
    },
    {
      path: "/doctor/update",
      pathChildName: "Update",
    },
    {
      path: "/doctor/delete",
      pathChildName: "Delete",
    },
  ],
  DoctorPosition: [{ path: "/doctorposition/create", pathChildName: "Create" }],
  Patient: [
    {
      path: "/patient/create",
      pathChildName: "Create",
    },
    {
      path: "/patient/update",
      pathChildName: "Update",
    },
    {
      path: "/patient/delete",
      pathChildName: "Delete",
    },
  ],
};

export { router, routes };
