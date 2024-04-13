import { Route, Routes } from "../../models/routes.model";
import CreateDoctor from "../../pages/doctor/CreateDoctor";
import Home from "../../pages/home/Home";
import CreatePatient from "../../pages/patient/CreatePatient";
import NotFound from "../components/NotFound";

const router: Route[] = [
  { path: "/", element: <Home /> },
  { path: "/doctor/create", element: <CreateDoctor /> },
  { path: "/patient/create", element: <CreatePatient /> },
  { path: "*", element: <NotFound /> },
];

const routes: Routes = {
  Doctor: [
    {
      path: "/doctor/create",
      pathChildName: "Create",
    },
  ],
  Patient: [
    {
      path: "/patient/create",
      pathChildName: "Create",
    },
  ],
};

export { router, routes };
