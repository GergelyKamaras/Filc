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
import AppIndex from './Pages/Home/AppIndex';
import RegisterUser from './Pages/Registration/RegisterUser';
import MySchool from './Pages/Students/MySchool';
import { ListData } from './Pages/ListData';
import {useState} from 'react';


function App() {

    const [loginStatus, updateLoginStatus] = useState(true);

    return (
        <>
            <ul>
                <li><Link to="/allstudents">Get all Students</Link></li>
                <li><Link to="/allteachers">Get all Teachers</Link></li>
                <li><Link to="/schooladmin/allschooladmins">Get all School admins</Link></li>
            </ul>   
        <Routes>
                <Route path="/allstudents" element={<ListData URL="https://localhost:7014/api/schooladmins/students" />} />
                <Route path="/allstudents/:id" element="student" />
                
                <Route path="/allteachers" element={<ListData URL="https://localhost:7014/api/schooladmins/teachers" />} />
                <Route path="/allteachers/:id" element="teacher" />

                <Route path="/allschooladmins" element={<ListData URL="https://localhost:7014/api/governmentadmins/schooladmins" />} />
                <Route path="/allschooladmins/:id" element="school admin" />


        <Route path="/" element={<Layout loginStatus={loginStatus} updateLoginStatus={updateLoginStatus}/>}>
          {/*Routes available to all users*/}
          <Route path="" element={<IndexPage loginStatus={loginStatus} updateLoginStatus={updateLoginStatus}/>} />
          <Route path="Unauthorized" element={<Unauthorized />} />

          {/*TODO: Routes available to Students*/}
          <Route element={<RequireAuth allowedRoles={["Student"]} />}>
          </Route>

          {/*TODO: Routes available to Teachers*/}
          <Route element={<RequireAuth allowedRoles={["Teacher"]} />}>
          </Route>

          {/*TODO: Routes available to SchoolAdmins*/}
          <Route path="schooladmin" element={<RequireAuth allowedRoles={["SchoolAdmin"]} />}>
            <Route path="allschooladmins" element={<ListData URL="https://localhost:7014/api/governmentadmins/schooladmins" />} />
          </Route>

          {/*TODO: Routes available to GovAdmins*/}
          <Route path="govadmin" element={<RequireAuth allowedRoles={["Government"]} />}>
            <Route path="schools/:schoolid/admins" element={<SchoolAdmins />} />
            <Route path="schooladmins/:id" element={<SchoolAdmin />} />
            <Route path="schools/" element={<Schools />} />
            <Route path="schools/:id" element={<School />} />
          </Route>

          {/*Not Existing Route*/}
          <Route path="*" element={<NotFound />} /></Route>
            </Routes>
        </>

    );
}

export default App;
