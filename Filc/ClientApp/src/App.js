

import './App.css';
import { Routes, Route } from 'react-router-dom'
import Layout from './components/Layout'
import RequireAuth from './components/RequireAuth';
import Unauthorized from './components/Unauthorized';
import NotFound from './components/NotFound';
import GovAdmins from './components/UserComponents/GovAdminComponents/Components/GovAdmins';
import GovAdmin from './components/UserComponents/GovAdminComponents/Components/GovAdmin';
import SchoolAdmins from './components/UserComponents/GovAdminComponents/Components/SchoolAdmins';
import SchoolAdmin from './components/UserComponents/GovAdminComponents/Components/SchoolAdmin';
import Schools from './components/UserComponents/GovAdminComponents/Components/Schools';
import School from './components/UserComponents/GovAdminComponents/Components/School';
import AppIndex from './Pages/AppIndex';
import LoginPage from './Pages/LoginPage';

function App() {


    return (
      <Routes>
        <Route path="/" element={<Layout />}>
          {/*Routes available to all users*/}
          <Route path="" element={<AppIndex />} />
          <Route path='/login' element={<LoginPage/>}/>
          <Route path="Unauthorized" element={<Unauthorized />} />

          {/*TODO: Routes available to Students*/}
          <Route element={<RequireAuth allowedRoles={["Student"]} />}>
          </Route>

          {/*TODO: Routes available to Teachers*/}
          <Route element={<RequireAuth allowedRoles={["Teacher"]} />}>
          </Route>

          {/*TODO: Routes available to SchoolAdmins*/}
          <Route element={<RequireAuth allowedRoles={["SchoolAdmin"]} />}>
          </Route>

          {/*TODO: Routes available to GovAdmins*/}
          <Route path="govadmin" element={<RequireAuth allowedRoles={["GovAdmin"]} />}>
            <Route path="schools/:schoolid/admins" element={<SchoolAdmins />} />
            <Route path="schooladmins/:id" element={<SchoolAdmin />} />
            <Route path="schools/" element={<Schools />} />
            <Route path="schools/:id" element={<School />} />
          </Route>

          {/*Not Existing Route*/}
          <Route path="*" element={<NotFound />} />
        </Route>
      </Routes>
    );
}

export default App;
