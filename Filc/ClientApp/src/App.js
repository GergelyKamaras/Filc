import IndexPage from './Pages/Home/AppIndex'
import './App.css';
import { Routes, Route, Link } from 'react-router-dom'
import Layout from './Pages/Shared/Layout'
import RequireAuth from './Pages/Other/RequireAuth';
import Unauthorized from './Pages/Other/Unauthorized';
import NotFound from './Pages/Other/NotFound';
import RegisterUser from './Pages/Registration/RegisterUser';
import MySchool from './Pages/Students/MySchool';
import { ListData } from './Pages/ListData';
import { useState, useEffect } from 'react';
import AddMark from "./Pages/Teacher/AddMark";
import jwt from 'jwt-decode';
import AddSchool from './Pages/Schools/AddSchool'
import AddSubject from './Pages/Subjects/AddSubject';
import AddLesson from './Pages/Lessons/AddLesson';

import { useLocation } from 'react-router-dom';
        
function App() {
    let location = useLocation().pathname

  const [loginStatus, updateLoginStatus] = useState(true);
  const [loginForm, updateLoginForm] = useState({});
  const [pageTitle, updatePageTitle] = useState('Home page');
  
  useEffect(() => {
    switch (location) {
      case "/":
          updatePageTitle("Home page");
          break;
      case "/profile":
          updatePageTitle("Profile page");
          break;
      case "/student/myschool":
          updatePageTitle("School Details");
          break;
      case "/schooladmin/register":
          updatePageTitle("User Registration");
          break;
      case "/govadmin/schools":
          updatePageTitle("Educational institutions");
          break;
      case "/govadmin/schooladmins":
          updatePageTitle("Institutional administrators");
          break;
      case "/govadmin/students":
          updatePageTitle("Student directory");
          break;
      case "/govadmin/teachers":
          updatePageTitle("Teacher directory");
          break;
      case "/govadmin/addschool":
          updatePageTitle("Institutional registration")
          break;
      default:
          // handle any unanticipated locations here
  }
  },[location])


  return (
    <>
      {/*COMMENT: Main Router Tag*/}
      <Routes>

        {/*COMMENT: Login Status Checker*/}
        {/*WARNING: Do not touch it, unless it is a team decision!*/}
        <Route path="/" element={<Layout loginStatus={loginStatus} updateLoginStatus={updateLoginStatus} loginForm={loginForm} pageTitle={pageTitle}/>}>

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
                    <Route path="teacher" element={<RequireAuth allowedRoles={["Teacher"]} />}>
                      <Route path="teachers" element={<ListData URL={localStorage.length > 0 ? "teachers/" + jwt(localStorage.AccessToken)["schoolId"] : ""} />} />
                      <Route path="add-grade" element={<AddMark />} />
                        {/*COMMENT: If you want to add a new Route, follow the example below and add it BETWEEN the Teacher Route tags!*/}
                        {/*<Route path="pathname" element={/* <Component propname={propname} />} />*/}
                    </Route>

                                                                          
          {/*ROUTE: Routes available to SchoolAdmins*/}
          <Route path="schooladmin" element={<RequireAuth allowedRoles={["SchoolAdmin", "Government"]} />}>
              <Route path="register" element={<RegisterUser />} />
              <Route path="addsubject" element={<AddSubject />} />
              <Route path="addlesson" element={<AddLesson />} />
              {/*COMMENT: If you want to add a new Route, follow the example below and add it BETWEEN the SchoolAdmin Route tags!*/}
              {/*<Route path="pathname" element={/* <Component propname={propname} />} />*/}
          </Route>


          {/*ROUTE: Routes available to GovAdmins*/}
          <Route path="govadmin" element={<RequireAuth allowedRoles={["Government"]} />}>
              <Route path="all" element={<ListData URL="" />} />/
              <Route path="addschool" element={<AddSchool />} />
              <Route path="students" element={<ListData URL="students" />} />
              <Route path="teachers" element={<ListData URL="teachers" />} />
              <Route path="schools" element={<ListData URL="schools" />} />
              <Route path="schooladmins" element={<ListData URL="schooladmins" />} />
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
