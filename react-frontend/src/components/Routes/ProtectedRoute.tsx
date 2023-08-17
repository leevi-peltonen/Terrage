import React from 'react';
import { useSelector } from 'react-redux';
import { Navigate, Outlet } from 'react-router-dom';
import { RootState } from '../../features/rootReducer';

const ProtectedRoutes = () => {

  const { token } = useSelector((state: RootState) => state.auth)


  return token ? <Outlet /> : <Navigate to="/login" />
}

export default ProtectedRoutes