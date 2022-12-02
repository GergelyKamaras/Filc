import Button from 'react-bootstrap/Button';
import Container from 'react-bootstrap/Container';
import Form from 'react-bootstrap/Form';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import NavDropdown from 'react-bootstrap/NavDropdown';
import Offcanvas from 'react-bootstrap/Offcanvas';
import {Link, useNavigate} from 'react-router-dom';
import {useEffect, useState} from 'react'
import InnerProfil from './IndexPageComponents/InnerProfil'

import "../Style/navbar.css"
function Header() {
    const role = localStorage.getItem("userRole");
    const navigate = useNavigate();
    const logout = () => {
        localStorage.clear();
        navigate("")
    }
    const govAdminFuncts =<>
     <Nav.Link href="govadmin/schools">All Schools</Nav.Link>
    <Nav.Link href="govadmin/schooladmins/1">School Administrators</Nav.Link>
    <Nav.Link href="#action3">All Students</Nav.Link>
    <Nav.Link href="#action2">View national statistics</Nav.Link>
    </>
    const standard =
    <>
    <Nav.Link href="">Login first</Nav.Link>
    </>
    useEffect(()=>{
      setFucts(
        (role===null) ? 
          standard
        :
        govAdminFuncts
      
      )
  },[localStorage.getItem("userRole")])
  const [fucts, setFucts] = useState(
    <>
      <Nav.Link href="">Login first</Nav.Link>
    </>
  )
  return (
    <>
      {[false].map((expand) => (
        <Navbar key={expand} bg="light" expand={expand} className="mb-3 navbar">
          <Container fluid>
            <Navbar.Brand className='navbar-title' href="">For Interactive Learning Community</Navbar.Brand>
            <Navbar.Toggle aria-controls={`offcanvasNavbar-expand-${expand}`} />
            <Navbar.Offcanvas
              id={`offcanvasNavbar-expand-${expand}`}
              aria-labelledby={`offcanvasNavbarLabel-expand-${expand}`}
              placement="end"
            >
              <Offcanvas.Header closeButton>
                <Offcanvas.Title id={`offcanvasNavbarLabel-expand-${expand}`}>
                    System Management Access
                </Offcanvas.Title>
              </Offcanvas.Header>
              <Offcanvas.Body>
                <Nav className="justify-content-end flex-grow-1 pe-3">
                  {
                  
                    fucts
                  }
                    
                  
                  
                  {
                      role ? 
                  <NavDropdown
                    title="Profile manager"
                    id={`offcanvasNavbarDropdown-expand-${expand}`}
                    >
                        <NavDropdown.Item href="#action3">Edit personal data</NavDropdown.Item>
                        <NavDropdown.Item href="#action4">Change password</NavDropdown.Item>
                        <NavDropdown.Item href="#action5">Settings</NavDropdown.Item>
                        <NavDropdown.Item onClick={(e) => e.preventDefault(), logout}>Logout</NavDropdown.Item>
                  </NavDropdown>
                  :
                  <NavDropdown
                  title="Not logged in"
                  id={`offcanvasNavbarDropdown-expand-${expand}`}
                  >
                      
                  </NavDropdown>
                  }
                </Nav>
                {/* <Form className="d-flex">
                  <Form.Control
                    type="search"
                    placeholder="Search"
                    className="me-2"
                    aria-label="Search"
                  />
                  <Button variant="outline-success">Search</Button>
                </Form> */}
              </Offcanvas.Body>
            </Navbar.Offcanvas>
          </Container>
        </Navbar>
      ))}
    </>
  );
}


export default Header;