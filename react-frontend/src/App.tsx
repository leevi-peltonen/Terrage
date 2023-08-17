import React from 'react';
import MainLayout from './pages/MainLayout';
import './App.css';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import Login from './pages/Login';
import Home from './pages/Home';
import Register from './pages/Register';
import Village from './pages/Village';
import ProtectedRoutes from './components/Routes/ProtectedRoute';
import Settings from './pages/Settings';
function App() {

  return (
    <BrowserRouter>
      <Routes>
        <Route 
          path="login" 
          element={
            <MainLayout>
              <Login />
            </MainLayout>
          }
        />

        <Route 
          path="register"
          element={
            <MainLayout>
              <Register />
            </MainLayout>
          }
        />

        <Route path="/" element={<ProtectedRoutes/>} >

          <Route 
            path="/"
            element={
              <MainLayout>
                <Home />
              </MainLayout>
            }
          />

          <Route path="/village" element={
            <MainLayout>
              <Village />
            </MainLayout>
          } />

          <Route path="/settings" element={
            <MainLayout>
              <Settings />
            </MainLayout>
          }/>

        <Route 
          path="*"
          element={
            <MainLayout>
              <Home />
            </MainLayout>
          }
        />
        </Route>
      </Routes>
    </BrowserRouter>
  );
}

export default App;
