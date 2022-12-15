

import './App.css';
import { Routes, Route } from 'react-router-dom'
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
import Marks from './Pages/Students/Marks';
import Mark from './Pages/Students/Mark';

function App() {


    return (
        <Routes>
            <Route path="/" element={<Layout />} >

                {/*Routes available to all users without login*/}
                <Route path="" element={<AppIndex/>} />
                <Route path="Unauthorized" element={<Unauthorized />} />

                {/*TODO: Routes available to Students*/}
                <Route path="student" element={<RequireAuth allowedRoles={["Student"]} />} >
                    <Route path="myschool" element={<MySchool />} />
                    <Route path="marks" element={<Marks />} />
                    <Route path="marks/id" element={<Mark /> } />
                </Route>
          
                {/*TODO: Routes available to Teachers*/}
                <Route element={<RequireAuth allowedRoles={["Teacher"]} />} >
                    {/* Routes indented here */}
                </Route>
          
                {/*TODO: Routes available to SchoolAdmins*/}
                <Route path="schooladmin" element={<RequireAuth allowedRoles={["SchoolAdmin","Government"]} />} >
                    <Route path="register" element={<RegisterUser />} />
                </ Route>

                {/*TODO: Routes available to GovAdmins*/}
                <Route path="govadmin" element={<RequireAuth allowedRoles={["Government"]} />} >
                    <Route path="schools/:schoolid/admins" element={<SchoolAdmins />} />
                    <Route path="schooladmins/:id" element={<SchoolAdmin />} />
                    <Route path="schools/" element={<Schools />} />
                    <Route path="schools/:id" element={<School />} />
                </ Route>
    
                {/*Not Existing Route*/}
                <Route path="*" element={<NotFound />} />
            </ Route>
      </Routes>
    );
}

export default App;
