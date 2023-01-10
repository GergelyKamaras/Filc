import IndexPage from './Pages/Home/AppIndex'
import './App.css';
import { Routes, Route, Link } from 'react-router-dom'
import Layout from './Pages/Shared/Layout'
import RequireAuth from './Pages/Other/RequireAuth';
import Unauthorized from './Pages/Other/Unauthorized';
import NotFound from './Pages/Other/NotFound';
import SchoolAdmins from './Pages/SchoolAdmin/SchoolAdmins';
import SchoolAdmin from './Pages/SchoolAdmin/SchoolAdmin';
import Schools from './Pages/Schools/Schools';
import School from './Pages/Schools/School';
import RegisterUser from './Pages/Registration/RegisterUser';
import MySchool from './Pages/Students/MySchool';
import { ListData } from './Pages/ListData';
import {useState} from 'react';

        
function App() {

    const [loginStatus, updateLoginStatus] = useState(true);
    const [loginForm, updateLoginForm] = useState({});
    const [pageTitle, updatePageTitle] = useState({});

    return (
      <>
        {/*COMMENT: Main Router Tag*/}
        <Routes>

          {/*COMMENT: Login Status Checker*/}
          {/*WARNING: Do not touch it, unless it is a team decision!*/}
          <Route path="/" element={<Layout loginStatus={loginStatus} updateLoginStatus={updateLoginStatus} loginForm={loginForm} pageTitle={pageTitle} updatePageTitle={updatePageTitle}/>}>
  
            {/*ROUTE: Routes available to all users*/}
            {/*WARNING: Routes available to all users do not have a wrap structure, thus we collect them here (except the Not Found route)*/}
            <Route path="" element={<IndexPage loginStatus={loginStatus} updateLoginStatus={updateLoginStatus} loginForm={loginForm} updateLoginForm={updateLoginForm}/>} />
            <Route path="Unauthorized" element={<Unauthorized />} />
            {/*COMMENT: If you want to add a new Route, follow the example below*/}
            {/*<Route path="pathname" element={/* <Component propname={propname} />} />*/}


            {/*ROUTE: Routes available to Students*/}
            <Route element={<RequireAuth allowedRoles={["Student"]} />}>
                <Route path="student/myschool" element={<MySchool />} />
                {/*COMMENT: If you want to add a new Route, follow the example below and add it BETWEEN the Student Route tags!*/}
                {/*<Route path="pathname" element={/* <Component propname={propname} />} />*/}
            </Route>


            {/*ROUTE: Routes available to Teachers*/}
            <Route element={<RequireAuth allowedRoles={["Teacher"]} />}>
                {/*COMMENT: If you want to add a new Route, follow the example below and add it BETWEEN the Teacher Route tags!*/}
                {/*<Route path="pathname" element={/* <Component propname={propname} />} />*/}
            </Route>

                                                                            
            {/*ROUTE: Routes available to SchoolAdmins*/}
            <Route path="schooladmin" element={<RequireAuth allowedRoles={["SchoolAdmin", "Government"]} />}>
                <Route path="register" element={<RegisterUser />} />
                {/*COMMENT: If you want to add a new Route, follow the example below and add it BETWEEN the SchoolAdmin Route tags!*/}
                {/*<Route path="pathname" element={/* <Component propname={propname} />} />*/}
            </Route>


            {/*ROUTE: Routes available to GovAdmins*/}
            <Route path="govadmin" element={<RequireAuth allowedRoles={["Government"]} />}>
                <Route path="all" element={<ListData URL="https://localhost:7014/api/governmentadmins" />} />
                <Route path="addschool" element={<Schools />} />
                <Route path="students" element={<ListData URL="https://localhost:7014/api/governmentadmins/students" />} />
                <Route path="teachers" element={<ListData URL="https://localhost:7014/api/governmentadmins/teachers" />} />
                <Route path="schools" element={<ListData URL="https://localhost:7014/api/governmentadmins/schools" />} />
                <Route path="schooladmins" element={<ListData URL="https://localhost:7014/api/governmentadmins/schooladmins" />} />
                {/*COMMENT: If you want to add a new Route, follow the example below and add it BETWEEN the SchoolAdmin Route tags!*/}
                {/*<Route path="pathname" element={/* <Component propname={propname} />} />*/}
                {/*COMMENT: Previously used routes, awaiting REMOVAL for finished project, currently kept if we need them*/}
                    {/*<Route path="schools/:schoolid/admins" element={<SchoolAdmins />} />*/}
                    {/*<Route path="schooladmins/:id" element={<SchoolAdmin />} />*/}
                    {/*<Route path="schools/" element={<Schools />} />*/}
                    {/*<Route path="schools/:id" element={<School />} />*/}
            </Route>


            {/*ROUTE: Not Existing Route*/}
            {/*COMMENT: If the user wants to navigate to a non-existing route, he/she will be redirected to this page*/}
            {/*WARNING: Do not touch it, unless it is a team decision!*/}
            <Route path="*" element={<NotFound />} />

          </Route>

        </Routes>
      </>

    );
}

export default App;
