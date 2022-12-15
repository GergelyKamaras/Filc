import './App.css';
import { Routes, Route, Link } from 'react-router-dom'
import Layout from './components/Layout'
import RequireAuth from './components/RequireAuth';
import Unauthorized from './components/Unauthorized';
import NotFound from './components/NotFound';
import SchoolAdmins from './components/UserComponents/GovAdminComponents/Components/SchoolAdmins';
import SchoolAdmin from './components/UserComponents/GovAdminComponents/Components/SchoolAdmin';
import Schools from './components/UserComponents/GovAdminComponents/Components/Schools';
import School from './components/UserComponents/GovAdminComponents/Components/School';
import IndexPage from './Pages/AppIndex';
import LoginPage from './Pages/LoginPage';
import { ListData } from './Pages/ListData';

function App() {
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

        <Route path="/" element={<Layout />}>
          {/*Routes available to all users*/}
          <Route path="" element={<IndexPage/>} />
          <Route path='/login' element={<LoginPage/>}/>
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
