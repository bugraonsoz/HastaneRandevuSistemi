import Grid from '@mui/material/Grid';
import Spent from './spent';
import Clients from './clients';
import Earnings from './earnings';
import Activity from './activity';

const TopCards = () => {
  return (
    <Grid container spacing={2.5}>
      <Grid item xs={12} sm={6} xl={3}>
        <Spent />
      </Grid>
      <Grid item xs={12} sm={6} xl={3}>
        <Clients />
      </Grid>
      <Grid item xs={12} sm={6} xl={3}>
        <Earnings />
      </Grid>
      <Grid item xs={12} sm={6} xl={3}>
        <Activity />
      </Grid>
    </Grid>
  );
};

export default TopCards;
