import Grid from '@mui/material/Grid';
import TopCards from 'components/sections/dashboard/top-cards';
import AvatarCard from 'components/sections/dashboard/avatar-card';
import TotalSpent from 'components/sections/dashboard/total-spent';
import Balance from 'components/sections/dashboard/balance';
import SpentThisMonth from 'components/sections/dashboard/spent-this-month';
import Transactions from 'components/sections/dashboard/transactions';
import Tasks from 'components/sections/dashboard/tasks';
import Earnings from 'components/sections/dashboard/earnings';
import CreditBalance from 'components/sections/dashboard/credit-balance';
import TransactionHistory from 'components/sections/dashboard/transaction-history';

const Dashbaord = () => {
  return (
    <Grid container spacing={2.5}>
      <Grid item xs={12}>
        <TopCards />
      </Grid>

      <Grid item xs={12} md={8}>
        <TotalSpent />
      </Grid>

      <Grid item xs={12} md={4}>
        <AvatarCard />
      </Grid>

      <Grid item xs={12} md={8}>
        <Balance />
      </Grid>

      <Grid item xs={12} md={4}>
        <SpentThisMonth />
      </Grid>

      <Grid item xs={12} md={4}>
        <Transactions />
      </Grid>

      <Grid item xs={12} md={4}>
        <Tasks />
      </Grid>

      <Grid item xs={12} md={4}>
        <Earnings />
      </Grid>

      <Grid item xs={12} md={4}>
        <CreditBalance />
      </Grid>

      <Grid item xs={12} md={8}>
        <TransactionHistory />
      </Grid>
    </Grid>
  );
};

export default Dashbaord;
