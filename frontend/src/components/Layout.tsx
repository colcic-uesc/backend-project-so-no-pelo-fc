import React from 'react'
import Header from './Header';
import Footer from './Footer';
import { useLocation } from 'react-router-dom';

interface LayoutProps {
  children: React.ReactNode;
}

export default function Layout({ children }:LayoutProps) {
  const location = useLocation()
  const excludedRoutes = ['/login']

  const isExcluded = excludedRoutes.includes(location.pathname)

  if(isExcluded)
    return (
      <section>{ children }</section>
    )

  return (
    <React.Fragment>
      <Header />
      <main>{ children }</main>
      <Footer />
    </React.Fragment>
  )
}
