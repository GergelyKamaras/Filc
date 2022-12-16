import NavbarLinks from '../Navbar/NavbarLinks'
import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import NavDropdown from 'react-bootstrap/NavDropdown';
import Offcanvas from 'react-bootstrap/Offcanvas';
import {useNavigate} from 'react-router-dom';
import React, {useEffect, useState} from 'react'
import "../../Style/navbar.css"
import jwt from 'jwt-decode'
import { NavItem } from 'react-bootstrap';


function Header({loginStatus, updateLoginStatus}) {
  const [role , updateRole] = useState(null)
  
    
  useEffect(() => {
    
    try{
      updateRole(jwt(localStorage?.AccessToken)["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"])
      console.log("you are logged in")
    }catch{
      console.log("not logged in")
    }
  },[loginStatus])
  
  
    const navigate = useNavigate();
    const logout = (e) => {
      e.preventDefault();
      localStorage.clear();
      navigate("")
      updateRole(null)
      updateLoginStatus(true)
    }

  
  return (
    <>
      {[false].map((expand) => (
        <Navbar role={role} key={expand} bg="light" expand={expand} className="mb-3 navbar">
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
                <Nav.Link href='/'>Home</Nav.Link>
                <Nav className="justify-content-end flex-grow-1 pe-3">
                  {role !== null ?   
                    ( <div>
                      <NavbarLinks role={role} />
                      

                      <NavDropdown
                        title="Profile manager"
                        id={`offcanvasNavbarDropdown-expand-${expand}`}
                        >
                            <NavDropdown.Item href="#action3">Edit personal data</NavDropdown.Item>
                            <NavDropdown.Item href="#action4">Change password</NavDropdown.Item>
                            <NavDropdown.Item href="#action5">Settings</NavDropdown.Item>
                            <NavDropdown.Item onClick={(e) => logout(e)}>Logout</NavDropdown.Item>
                      </NavDropdown>
                    </div>)
                  :
                  
                  (<NavItem>
                    You are not logged in, please login first
                  </NavItem> )}
                  
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